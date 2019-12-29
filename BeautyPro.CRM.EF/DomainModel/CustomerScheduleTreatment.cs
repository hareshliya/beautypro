using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerScheduleTreatment")]
    public partial class CustomerScheduleTreatment
    {
        public CustomerScheduleTreatment()
        {
            TblCustomerInvoiceHeader = new HashSet<CustomerInvoiceHeader>();
        }

        public int Cstid { get; set; }
        public int Csid { get; set; }
        public int Ttid { get; set; }
        public int Empno { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Qty { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual CustomerSchedule CustomerSchedule { get; set; }
        public virtual EmployeeDetail Employee { get; set; }
        public virtual TreatmentType Tt { get; set; }
        public virtual ICollection<CustomerInvoiceHeader> TblCustomerInvoiceHeader { get; set; }
    }
}
