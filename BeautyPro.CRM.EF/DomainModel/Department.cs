using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Mast_Department")]
    public partial class Department
    {
        public Department()
        {
            TblCustomerGiftVoucher = new HashSet<CustomerGiftVoucher>();
            TblCustomerInvoiceHeader = new HashSet<CustomerInvoiceHeader>();
            TblCustomerSchedule = new HashSet<CustomerSchedule>();
            EmployeeDetail = new HashSet<EmployeeDetail>();
            TreatmentTypes = new HashSet<TreatmentType>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsMain { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<CustomerGiftVoucher> TblCustomerGiftVoucher { get; set; }
        public virtual ICollection<CustomerInvoiceHeader> TblCustomerInvoiceHeader { get; set; }
        public virtual ICollection<CustomerSchedule> TblCustomerSchedule { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetail { get; set; }
        public virtual ICollection<TreatmentType> TreatmentTypes { get; set; }
    }
}
