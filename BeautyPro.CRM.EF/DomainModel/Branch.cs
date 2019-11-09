using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Branch")]
    public partial class Branch
    {
        public Branch()
        {
            TblCustomer = new HashSet<Customer>();
            TblMastDepartment = new HashSet<Department>();
            TblMastDesignation = new HashSet<TblMastDesignation>();
            TblMastTreatmentType = new HashSet<TreatmentType>();
        }

        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tp1 { get; set; }
        public string Tp2 { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int CompanyId { get; set; }

        public virtual TblCompany Company { get; set; }
        public virtual ICollection<Customer> TblCustomer { get; set; }
        public virtual ICollection<Department> TblMastDepartment { get; set; }
        public virtual ICollection<TblMastDesignation> TblMastDesignation { get; set; }
        public virtual ICollection<TreatmentType> TblMastTreatmentType { get; set; }
    }
}
