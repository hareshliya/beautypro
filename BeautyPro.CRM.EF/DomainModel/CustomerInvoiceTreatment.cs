using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerInvoiceTreatment")]
    public partial class CustomerInvoiceTreatment
    {
        public int Citid { get; set; }
        public string InvoiceNo { get; set; }
        public int Ttid { get; set; }
        public int Empno { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Cstid { get; set; }
        //public decimal SubTotalAmount { get; set; }
        //public decimal TaxAmount { get; set; }
        //public decimal DueAmount { get; set; }
        public virtual CustomerScheduleTreatment Cst { get; set; }
        public virtual EmployeeDetail EmpnoNavigation { get; set; }
        public virtual CustomerInvoiceHeader InvoiceNoNavigation { get; set; }
        public virtual TreatmentType Tt { get; set; }
    }
}
