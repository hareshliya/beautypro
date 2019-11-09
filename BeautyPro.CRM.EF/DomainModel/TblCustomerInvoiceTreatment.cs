using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblCustomerInvoiceTreatment
    {
        public int Citid { get; set; }
        public string InvoiceNo { get; set; }
        public int Ttid { get; set; }
        public int Empno { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        public virtual EmployeeDetail EmpnoNavigation { get; set; }
        public virtual TblCustomerInvoiceHeader InvoiceNoNavigation { get; set; }
        public virtual TreatmentType Tt { get; set; }
    }
}
