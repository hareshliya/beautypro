using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class DepartmentDTO
    {
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
    }
}
