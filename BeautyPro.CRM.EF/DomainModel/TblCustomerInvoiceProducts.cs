using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblCustomerInvoiceProducts
    {
        public int Cipid { get; set; }
        public string InvoiceNo { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Qty { get; set; }

        public virtual TblCustomerInvoiceHeader InvoiceNoNavigation { get; set; }
    }
}
