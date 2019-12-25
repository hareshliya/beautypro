using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceTreatmentResponse
    {
        public string TreatmentName { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public int EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public int CustomerScheduleTreatmentId { get; set; }
        public int TreatmentTypeId { get; set; }
    }
}
