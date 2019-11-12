using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.Enums;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerGiftVoucherService : ICustomerGiftVoucherService
    {
        private readonly ICustomerGiftVoucherRepository _customerGiftVoucherRepository;
        public CustomerGiftVoucherService(
            ICustomerGiftVoucherRepository customerGiftVoucherRepository)
        {
            this._customerGiftVoucherRepository = customerGiftVoucherRepository;
        }

        public List<CustomerGiftVoucherDTO> GetAllVouchers(VoucherRequest request)
        {
            var vouchers =
                _customerGiftVoucherRepository
                .All;

            if(request.Status == VoucherStatus.Redeemed)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsRedeem).ToList());
            } 
            else if(request.Status == VoucherStatus.Canceled)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsCanceled).ToList());
            }
            else if (request.Status == VoucherStatus.Canceled)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsCanceled).ToList());
            }
            else if (request.Status == VoucherStatus.Canceled)
            {
                return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.Where(x => x.IsCanceled).ToList());
            }

            return DomainDTOMapper.ToCustomerGiftVoucherDTOs(vouchers.ToList());
        }

        public CustomerGiftVoucherDTO AddNewVoucher(CustomerGiftVoucherDTO voucher)
        {
            voucher.EnteredDate = DateTime.Now;
            voucher.EnteredBy = 1;
            voucher.InvDateTime = DateTime.Now;
            voucher.BranchId = 1;
            voucher.IsRedeem = false;
            voucher.IsCanceled = false;

            _customerGiftVoucherRepository.Add(DomainDTOMapper.ToCustomerGiftVoucherDomain(voucher));
            _customerGiftVoucherRepository.SaveChanges();
            return voucher;
        }
    }
}
