using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblEmployeeAttendance
    {
        public int AttendanceId { get; set; }
        public int Empno { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public decimal WorkedHrs { get; set; }
        public decimal LateMins { get; set; }
        public decimal Ot1 { get; set; }
        public string Status { get; set; }
        public int BranchId { get; set; }
        public int MonthId { get; set; }
    }
}
