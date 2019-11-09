using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblEmployeeBasicSalary
    {
        public int Ebsid { get; set; }
        public int Empno { get; set; }
        public decimal? BasicSalaryValue { get; set; }
        public int MonthId { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual EmployeeDetail EmpnoNavigation { get; set; }
    }
}
