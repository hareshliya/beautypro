using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class EmployeeDetailDTO
    {
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
    }
}
