﻿using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerGiftVoucherService
    {
        List<CustomerGiftVoucherDTO> GetAllVouchers(VoucherRequest request);
        void AddEditVoucher(CustomerGiftVoucherDTO voucher, int userId, int branchId);

        List<PaymentTypeDTO> GetPaymentTypes();

        void DeleteVoucher(VoucherDeleteRequest request, int userId);
    }
}
