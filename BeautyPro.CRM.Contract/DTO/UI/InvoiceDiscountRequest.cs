using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceDiscountRequest
    {
        //public decimal Discount { get; set; }
        //public string InvoiceNo { get; set; }
        public string User { get; set; }
        public string Otp { get; set; }
    }
}
