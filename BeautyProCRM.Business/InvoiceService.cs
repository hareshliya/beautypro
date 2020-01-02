using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using BeautyProCRM.Common.Enum;
using BeautyProCRM.Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICustomerInvoiceHeaderRepository _customerInvoiceHeaderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerGiftVoucherRepository _customerGiftVoucherRepository;

        public InvoiceService(
            ICustomerInvoiceHeaderRepository customerInvoiceHeaderRepository,
            IUserRepository userRepository,
            ICustomerGiftVoucherRepository customerGiftVoucherRepository)
        {
            _customerInvoiceHeaderRepository = customerInvoiceHeaderRepository;
            _userRepository = userRepository;
            _customerGiftVoucherRepository = customerGiftVoucherRepository; ;
        }


        public List<InvoiceDTO> GetAllInvoices(int departmentId)
        {
            return DomainDTOMapper.ToInvoiceDTOs(_customerInvoiceHeaderRepository
                .All
                .Where(x => x.DepartmentId == departmentId)
                .Include(x => x.Customer)
                .ToList());
        }

        public List<InvoiceDTO> GetAllFilteredInvoices(InvoiceFilterRequest request)
        {
            return DomainDTOMapper.ToInvoiceDTOs(_customerInvoiceHeaderRepository
                .All
                .Where(x => x.DepartmentId == request.DepartmentId 
                    && (x.Status == (int)request.Status || request.Status == InvoiceStatus.All) && x.InvDateTime.Date == request.Date.Date)
                .Include(x => x.Customer)
                .ToList());
        }

        public InvoiceDTO GetInvoiceDetails(string invNo)
        {
            return DomainDTOMapper.ToInvoiceDTO(_customerInvoiceHeaderRepository
                .All
                .Where(x => x.InvoiceNo == invNo)
                .Include(x => x.Customer)
                .Include(c => c.CustomerInvoiceTreatments)
                .Include(c => c.CustomerInvoiceProducts)
                .FirstOrDefault());
        }

        public string SaveInvoice(InvoiceSaveRequest request, int branchId, int userId)
        {
            try
            {
                /*decimal treatmentsSubTotal = request.Treatments != null ? request.Treatments.Sum(c => c.Price * c.Quantity) : 0.0M;
                // decimal treatmentsTax = (treatmentsSubTotal - request.TreatmentDiscount) * 0.06M;
                decimal treatmentsTax = treatmentsSubTotal * 0.06M;
                //decimal treatmentsDueAmount = treatmentsTax + (treatmentsSubTotal - request.TreatmentDiscount);
                decimal treatmentsDueAmount = treatmentsTax + treatmentsSubTotal;

                decimal productsSubTotal = request.Products != null ? request.Products.Sum(c => c.Price * c.Quantity) : 0.0M;
                decimal productsTax = (productsSubTotal) * 0.06M;
                decimal productsDueAmount = productsTax + productsSubTotal;*/

                var invoiceableTreatments = new List<CustomerInvoiceTreatment>();
                var invoiceableproducts = new List<CustomerInvoiceProducts>();

                if (request.Treatments != null && request.Treatments.Count > 0)
                {
                    foreach (var treatment in request.Treatments)
                    {
                        invoiceableTreatments.Add(new CustomerInvoiceTreatment()
                        {
                            Qty = treatment.Quantity,
                            Price = treatment.Price,
                            Cost = treatment.Cost,
                            Ttid = treatment.TreatmentTypeId,
                            Empno = treatment.EmployeeNo,
                            Cstid = treatment.CustomerScheduleTreatmentId,
                        });
                    }
                }

                if (request.Products != null && request.Products.Count > 0)
                {
                    foreach (var product in request.Products)
                    {
                        decimal subTotal = (product.Price * product.Quantity);
                        decimal tax = (subTotal) * 0.06M;

                        invoiceableproducts.Add(new CustomerInvoiceProducts()
                        {
                            Qty = product.Quantity,
                            Price = product.Price,
                            Cost = product.Cost,
                            Empno = product.RecomendedBy,
                            ProductId = product.ProductId
                        });
                    }
                }

                string invoiceNo = GenerateInvoiceNo();

                var invoiceHeader = new CustomerInvoiceHeader()
                {
                    InvoiceNo = invoiceNo,
                    BranchId = branchId,
                    EnteredBy = userId,
                    EnteredDate = DateTime.Now,
                    CustomerId = request.CustomerId,
                    InvDateTime = DateTime.Now,
                    //TransType = "Cash",
                    TransType = request.TransType,
                    Ptid = 1,
                    DepartmentId = request.DepartmentId,
                    // IsCanceled = false,
                    Status = (int)InvoiceStatus.Invoiced,
                    CustomerInvoiceProducts = invoiceableproducts,
                    CustomerInvoiceTreatments = invoiceableTreatments,
                    TreatmentSubTotalAmount = request.TreatmentSubTotal,
                    TreatmentDueAmount = request.TreatmentDueAmount,
                    TreatmentTaxAmount = request.TreatmentsTaxAmount,
                    ProductSubTotalAmount = request.ProductSubTotal,
                    ProductDueAmount = request.ProductDueAmount,
                    ProductTaxAmount = request.ProductsTaxAmount,
                    TreatmentDiscountAmount = request.TreatmentDiscountAmount,
                    CCTId = request.CreditCardTypeId,
                    GvinvoiceNo = !string.IsNullOrWhiteSpace(request.GvinvoiceNo) ? 
                                    request.GvinvoiceNo : null
                };

                _customerInvoiceHeaderRepository.Add(invoiceHeader);
                _customerInvoiceHeaderRepository.SaveChanges();

                if(!string.IsNullOrWhiteSpace(request.GvinvoiceNo) && request.GVRedeemedAmount > 0)
                {
                    ProcessVoucher(request.GvinvoiceNo, request.GVRedeemedAmount);
                }

                return invoiceNo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ProcessVoucher(string gvInvoiceNo, decimal redeemedAmount)
        {
            var giftVoucher = _customerGiftVoucherRepository
                .FirstOrDefault(x => x.GvinvoiceNo == gvInvoiceNo);

            if (giftVoucher != null && giftVoucher.DueAmount > 0)
            {              
                giftVoucher.DueAmount = redeemedAmount > giftVoucher.DueAmount ? 0 : giftVoucher.DueAmount - redeemedAmount;

                if (giftVoucher.DueAmount == 0)
                {
                    giftVoucher.IsRedeem = true;
                }

                _customerGiftVoucherRepository.SaveChanges();
            }
        }

        public bool ApplyDiscount(InvoiceDiscountRequest request)
        {
            var encryptedPassword = UserHelper.Encrypt(request.Otp);
            var user = _userRepository.FirstOrDefault(x => x.UserName == request.User);

            return user != null;              
        }

        public void CancelInvoice(string invoiceNo)
        {
            var invoiceHeader = _customerInvoiceHeaderRepository
                .FirstOrDefault(c => c.InvoiceNo == invoiceNo);

            if(invoiceHeader != null)
            {
                //invoiceHeader.IsCanceled = true;
                invoiceHeader.Status = (int)InvoiceStatus.Cancelled;
                _customerInvoiceHeaderRepository.SaveChanges();
            }
        }

        private string GenerateInvoiceNo()
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string newInvoiceNo = string.Empty;

            var invoiceNo = _customerInvoiceHeaderRepository.All
                .Where(x => x.InvoiceNo.Contains(timeStamp))
                .Select(c => Int64.Parse(c.InvoiceNo))
                .OrderByDescending(c => c)
                .FirstOrDefault();

            if(invoiceNo == 0)
            {
                newInvoiceNo = string.Format("{0}{1}", timeStamp, "001");
            }
            else
            {
                var strNo = invoiceNo.ToString();
                var lastNumber = int.Parse(strNo.Substring(strNo.Length - 3));
                var newNumber = (lastNumber + 1).ToString();

                if (newNumber.Length == 3)
                {
                    newInvoiceNo = string.Format("{0}{1}", timeStamp, newNumber);
                }
                else if (newNumber.Length == 2)
                {
                    newInvoiceNo = string.Format("{0}{1}{2}", timeStamp, "0", newNumber);
                }
                else if (newNumber.Length == 1)
                {
                    newInvoiceNo = string.Format("{0}{1}{2}{3}", timeStamp, "0", "0", newNumber);
                }
            }

            return newInvoiceNo;
        }

    }
}
