using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class NewAppointmentRequest
    {
        public int CsId { get; set; }
        public string CustomerId { get; set; }
        public DateTime BookedDate { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public List<AppointmentTreatment> Treatments { get; set; }
    }

    public class AppointmentTreatment
    {
        public int Ttid { get; set; }
        public int EmpNo { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Qty { get; set; }
    }
}
