using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerSchedule")]
    public partial class CustomerSchedule
    {
        public CustomerSchedule()
        {
            CustomerScheduleTreatments = new HashSet<CustomerScheduleTreatment>();
        }

        public int Csid { get; set; }
        public string CustomerId { get; set; }
        public DateTime BookedDate { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CustomerScheduleTreatment> CustomerScheduleTreatments { get; set; }
    }
}
