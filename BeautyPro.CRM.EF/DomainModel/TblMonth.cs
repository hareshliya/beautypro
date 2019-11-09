using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblMonth
    {
        public int MonthId { get; set; }
        public string FinMonth { get; set; }
        public string FinYear { get; set; }
        public bool? IsDeleted { get; set; }
        public int? EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
