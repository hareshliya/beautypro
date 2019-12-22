using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Mast_TreatmentType")]
    public partial class TreatmentType
    {
        public TreatmentType()
        {
            TblCustomerGiftVoucher = new HashSet<CustomerGiftVoucher>();
            TblCustomerInvoiceTreatment = new HashSet<CustomerInvoiceTreatment>();
            TblCustomerScheduleTreatment = new HashSet<CustomerScheduleTreatment>();
        }

        public int Ttid { get; set; }
        public string Ttname { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Duration { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string ColorCode { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CustomerGiftVoucher> TblCustomerGiftVoucher { get; set; }
        public virtual ICollection<CustomerInvoiceTreatment> TblCustomerInvoiceTreatment { get; set; }
        public virtual ICollection<CustomerScheduleTreatment> TblCustomerScheduleTreatment { get; set; }
    }
}
