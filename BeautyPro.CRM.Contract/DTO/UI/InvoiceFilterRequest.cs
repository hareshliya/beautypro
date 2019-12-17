using BeautyProCRM.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceFilterRequest
    {
        public int DepartmentId { get; set; }
        public DateTime Date { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
