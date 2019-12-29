using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class InvoiceDTO
    {
        public string InvoiceNo { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Tax { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal DueAmount { get; set; }
        public List<InvoiceProductDTO> InvoiceProducts { get; set; }
        public List<InvoiceTreatmentDTO> InvoiceTreatments { get; set; }
    }
}
