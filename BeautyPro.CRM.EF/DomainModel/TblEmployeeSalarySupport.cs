using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblEmployeeSalarySupport
    {
        public int Essid { get; set; }
        public int Empno { get; set; }
        public string PaymentMethod { get; set; }
        public int NoOfPresentDays { get; set; }
        public string ChequNo { get; set; }
        public int MonthId { get; set; }
        public int BranchId { get; set; }
    }
}
