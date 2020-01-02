using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.Enums;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerGiftVoucherService : ICustomerGiftVoucherService
    {
        private readonly ICustomerGiftVoucherRepository _customerGiftVoucherRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IUserRepository _userRepository;

        public CustomerGiftVoucherService(
            ICustomerGiftVoucherRepository customerGiftVoucherRepository,
            IPaymentTypeRepository paymentTypeRepository,
            IUserRepository userRepository
            )
        {
            _customerGiftVoucherRepository = customerGiftVoucherRepository;
            _paymentTypeRepository = paymentTypeRepository;
            _userRepository = userRepository;
        }

        public List<CustomerGiftVoucherDTO> GetFilteredVouchers(VoucherRequest request)
        {
            var vouchers = _customerGiftVoucherRepository
                        .All
                        .Where(x => x.DepartmentId == request.DepartmentId)
                        .Include(x => x.Customer)
                        .Where(x => x.InvDateTime.Date == request.Date && !x.IsCanceled && x.CanceledBy == null)
                        .Join(_userRepository.All, n => n.EnteredBy, l => l.UserId, (v, usr) =>
                            UpdateCustomerGiftVoucherDomain(v,usr.UserName));

            if (request.Status == VoucherStatus.Redeemed)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsRedeem).ToList());
            } 
            else if(request.Status == VoucherStatus.Cancelled)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsCanceled).ToList());
            }
            else if (request.Status == VoucherStatus.Issued)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => !x.IsCanceled && !x.IsRedeem).ToList());
            }
            else if (request.Status == VoucherStatus.All)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.ToList());
            }

            return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.ToList());
        }

        public List<CustomerGiftVoucherDTO> GetIssuedVouchers(IssuedVoucherRequest request)
        {
            var vouchers = _customerGiftVoucherRepository
                        .All
                        .Include(x => x.Customer)
                        .Where(x => !x.IsCanceled && !x.IsRedeem && x.CustomerId == request.CustomerId)
                        .ToList();

            return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers);
        }

        public CustomerGiftVoucherDTO GetVoucher(string gvInvoiceNo)
        {
            return DomainDTOMapper.ToCustomerGiftVoucherDTO(_customerGiftVoucherRepository.FirstOrDefault(x => x.GvinvoiceNo == gvInvoiceNo));
        }

        private CustomerGiftVoucher UpdateCustomerGiftVoucherDomain(CustomerGiftVoucher gv, string issuedBy)
        {
            gv.IssuedBy = issuedBy;
            return gv;
        }

        public void AddEditVoucher(CustomerGiftVoucherDTO request, int userId, int branchId)
        {
            if (!string.IsNullOrWhiteSpace(request.GvinvoiceNo))
            {
                EditVoucher(request, userId, branchId);
            }
            else
            {
                AddVoucher(request, userId, branchId);
            }
        }

        private void AddVoucher(CustomerGiftVoucherDTO voucher, int userId, int branchId)
        {
            voucher.GvinvoiceNo = String.Format("V{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            voucher.EnteredDate = DateTime.Now;
            voucher.EnteredBy = userId;
            voucher.InvDateTime = DateTime.Now;
            voucher.BranchId = branchId;
            voucher.IsRedeem = false;
            voucher.IsCanceled = false;

            _customerGiftVoucherRepository.Add(DomainDTOMapper.ToCustomerGiftVoucherDomain(voucher));
            _customerGiftVoucherRepository.SaveChanges();
        }

        private void EditVoucher(CustomerGiftVoucherDTO request, int userId, int branchId)
        {
            var voucher = _customerGiftVoucherRepository.FirstOrDefault(x => x.GvinvoiceNo == request.GvinvoiceNo);

            if (voucher != null)
            {
                voucher.BranchId = branchId;
                voucher.CustomerId = request.CustomerId;
                //voucher.DepartmentId = request.DepartmentId;
                voucher.DueAmount = request.DueAmount;
                voucher.SubTotalAmount = request.DueAmount;
                //voucher.InvDateTime = request.InvDateTime;
                voucher.ModifiedBy = userId;
                voucher.ModifiedDate = DateTime.Now;
            }

            _customerGiftVoucherRepository.SaveChanges();
        }

        public void DeleteVoucher(VoucherDeleteRequest request, int userId)
        {
            var voucher = _customerGiftVoucherRepository
                .FirstOrDefault(x => x.GvinvoiceNo == request.GvinvoiceNo);

            if (voucher != null)
            {
                voucher.CanceledBy = userId;
                voucher.CanceledDate = DateTime.Now;
                voucher.CancelReason = request.CancelReason;

                _customerGiftVoucherRepository.SaveChanges();
            }

        }

        public List<PaymentTypeDTO> GetPaymentTypes()
        {
            var paymentTypes = _paymentTypeRepository
                .All
                .Where(x => !x.IsDeleted && x.DeletedBy == null)
                .ToList();

            return DomainDTOMapper.ToPaymentTypeDTOs(paymentTypes);
        }

        public void ChangeVoucherStatus(VoucherStatusRequest request)
        {
            var giftVoucher = _customerGiftVoucherRepository
                .FirstOrDefault(x => x.GvinvoiceNo == request.GVInvoiceNo);

            switch (request.Status)
            {
                case VoucherStatus.Cancelled:
                    giftVoucher.IsCanceled = true; giftVoucher.IsRedeem = false; break;

                case VoucherStatus.Redeemed:
                    giftVoucher.IsRedeem = true; giftVoucher.IsCanceled = false; break;

                case VoucherStatus.Issued:
                    giftVoucher.IsCanceled = false; giftVoucher.IsRedeem = false; break;
            }

            _customerGiftVoucherRepository.SaveChanges();
        }
    }
}
