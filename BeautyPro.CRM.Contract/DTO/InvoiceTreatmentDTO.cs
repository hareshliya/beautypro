using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class InvoiceTreatmentDTO
    {
        public int Citid { get; set; }
        public string InvoiceNo { get; set; }
        public int Ttid { get; set; }
        public string TreatmentTypeName { get; set; }
        public int Empno { get; set; }
        public string EmployeeName { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Cstid { get; set; }
    }
}
