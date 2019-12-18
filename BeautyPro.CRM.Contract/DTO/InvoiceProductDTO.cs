using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class InvoiceProductDTO
    {
        public int Cipid { get; set; }
        public string InvoiceNo { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Empno { get; set; }
        public string RecomendedBy { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Qty { get; set; }
    }
}
