﻿using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface IInvoiceService
    {
        void SaveInvoice(InvoiceSaveRequest request, int branchId, int userId);
        void ApplyDiscount(InvoiceDiscountRequest request);
        List<InvoiceDTO> GetAllInvoices(int departmentId);
        List<InvoiceDTO> GetInvoiceDetails(string invNo);
    }
}
