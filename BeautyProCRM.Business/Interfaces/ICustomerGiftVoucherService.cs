using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerGiftVoucherService
    {
        List<CustomerGiftVoucherDTO> GetAllVouchers(VoucherRequest request);
        CustomerGiftVoucherDTO AddNewVoucher(CustomerGiftVoucherDTO voucher);
    }
}
