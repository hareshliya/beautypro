using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface IInvoiceService
    {
        void SaveInvoice(InvoiceSaveRequest request, int branchId, int userId);
        bool ApplyDiscount(InvoiceDiscountRequest request);
        List<InvoiceDTO> GetAllInvoices(int departmentId);
        InvoiceDTO GetInvoiceDetails(string invNo);
        void CancelInvoice(string invoiceNo);
        List<InvoiceDTO> GetAllFilteredInvoices(InvoiceFilterRequest request);
    }
}
