using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_EmployeeDetail")]
    public partial class EmployeeDetail
    {
        public EmployeeDetail()
        {
            TblCustomerInvoiceTreatment = new HashSet<CustomerInvoiceTreatment>();
            TblCustomerScheduleTreatment = new HashSet<CustomerScheduleTreatment>();
            TblEmployeeAllowances = new HashSet<TblEmployeeAllowances>();
            TblEmployeeBasicSalary = new HashSet<TblEmployeeBasicSalary>();
            TblEmployeeCommision = new HashSet<TblEmployeeCommision>();
            TblEmployeeDeduction = new HashSet<TblEmployeeDeduction>();
            TblEmployeeLeave = new HashSet<TblEmployeeLeave>();
            EmployeeRosters = new HashSet<EmployeeRoster>();
        }

        public int Empno { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public int? NationalityId { get; set; }
        public int CountryId { get; set; }
        public string PassportNo { get; set; }
        public DateTime DateOfJoin { get; set; }
        public decimal BasicSalary { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactNo { get; set; }
        public int BankId { get; set; }
        public string BankAccountNo { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual TblMastBank Bank { get; set; }
        public virtual TblMastOriginCountry Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual TblMastDesignation Designation { get; set; }
        public virtual TblMastNationality Nationality { get; set; }
        public virtual ICollection<CustomerInvoiceTreatment> TblCustomerInvoiceTreatment { get; set; }
        public virtual ICollection<CustomerScheduleTreatment> TblCustomerScheduleTreatment { get; set; }
        public virtual ICollection<TblEmployeeAllowances> TblEmployeeAllowances { get; set; }
        public virtual ICollection<TblEmployeeBasicSalary> TblEmployeeBasicSalary { get; set; }
        public virtual ICollection<TblEmployeeCommision> TblEmployeeCommision { get; set; }
        public virtual ICollection<TblEmployeeDeduction> TblEmployeeDeduction { get; set; }
        public virtual ICollection<TblEmployeeLeave> TblEmployeeLeave { get; set; }
        public virtual ICollection<EmployeeRoster> EmployeeRosters { get; set; }
    }
}
