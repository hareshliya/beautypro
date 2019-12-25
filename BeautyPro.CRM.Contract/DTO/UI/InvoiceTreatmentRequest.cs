using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceTreatmentRequest
    {
        public string CustomerId { get; set; }
        public int DepartmentId { get; set; }
    }
}
