using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerInvoiceProducts")]
    public partial class CustomerInvoiceProducts
    {
        public int Cipid { get; set; }
        public string InvoiceNo { get; set; }
        public string ProductId { get; set; }
        public int Empno { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Qty { get; set; }
        //public decimal SubTotalAmount { get; set; }
        //public decimal TaxAmount { get; set; }
        //public decimal DueAmount { get; set; }
        public virtual EmployeeDetail EmpnoNavigation { get; set; }
        public virtual CustomerInvoiceHeader InvoiceNoNavigation { get; set; }
    }
}
