using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO
{
    public class TreatmentTypeDTO
    {
        public int Ttid { get; set; }
        public string Ttname { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Duration { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public string ColorCode { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
