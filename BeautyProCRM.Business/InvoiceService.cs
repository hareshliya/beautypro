using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICustomerInvoiceHeaderRepository _customerInvoiceHeaderRepository;
        public InvoiceService(
            ICustomerInvoiceHeaderRepository customerInvoiceHeaderRepository)
        {
            _customerInvoiceHeaderRepository = customerInvoiceHeaderRepository;
        }
        public void SaveInvoice(InvoiceSaveRequest request, int branchId, int userId)
        {
            try
            {
                decimal treatmentsSubTotal = request.Treatments != null ? request.Treatments.Sum(c => c.Price * c.Quantity) : 0.0M;
                decimal treatmentsDiscount = 0.0M;
                decimal treatmentsTax = (treatmentsSubTotal - treatmentsDiscount) * 0.06M;
                decimal treatmentsDueAmount = treatmentsTax + (treatmentsSubTotal - treatmentsDiscount);

                decimal productsSubTotal = request.Products != null ? request.Products.Sum(c => c.Price * c.Quantity) : 0.0M;
                decimal productsTax = (productsSubTotal) * 0.06M;
                decimal productsDueAmount = treatmentsTax + treatmentsSubTotal;

                var invoiceableTreatments = new List<CustomerInvoiceTreatment>();
                var invoiceableproducts = new List<CustomerInvoiceProducts>();

                if (request.Treatments != null && request.Treatments.Count > 0)
                {
                    foreach (var treatment in request.Treatments)
                    {
                        decimal subTotal = (treatment.Price * treatment.Quantity);
                        decimal discount = 0.0M;
                        decimal tax = (subTotal - discount) * 0.06M;

                        invoiceableTreatments.Add(new CustomerInvoiceTreatment()
                        {
                            Qty = treatment.Quantity,
                            Price = treatment.Price,
                            Cost = treatment.Price,
                            SubTotalAmount = subTotal,
                            //DiscountAmount = discount,
                            TaxAmount = tax,
                            DueAmount = tax + (subTotal - discount),
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
                            Cost = product.Price,
                            SubTotalAmount = subTotal,
                            TaxAmount = tax,
                            DueAmount = tax + subTotal,
                            Empno = product.RecomendedBy,
                            ProductId = product.ProductId
                        });
                    }
                }

                string invoiceNo = GenerateInvoiceNo();

                var invoiceHeader = new CustomerInvoiceHeader()
                {
                    InvoiceNo = invoiceNo,
                    //BranchId = branchId,
                    //EnteredBy = userId,
                    BranchId = 1,
                    EnteredBy = 1,
                    EnteredDate = DateTime.Now,
                    CustomerId = request.CustomerId,
                    InvDateTime = DateTime.Now,
                    TransType = "Cash",
                    Ptid = 1,
                    SubTotalAmount = treatmentsSubTotal + productsSubTotal,
                    DiscountAmount = treatmentsDiscount,
                    TaxAmount = treatmentsTax + productsTax,
                    DueAmount = treatmentsDueAmount + productsDueAmount,
                    DepartmentId = request.DepartmentId,
                    IsCanceled = false,
                    CustomerInvoiceProducts = invoiceableproducts,
                    CustomerInvoiceTreatment = invoiceableTreatments
                };

                _customerInvoiceHeaderRepository.Add(invoiceHeader);
                _customerInvoiceHeaderRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
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
