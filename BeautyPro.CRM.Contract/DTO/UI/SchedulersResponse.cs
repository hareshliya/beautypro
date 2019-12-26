using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class SchedulersResponse
    {
        public string EmployeeName { get; set; }
        public int EmpNo { get; set; }
        public string Designation { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }

    public class Schedule
    {
        public string ClientName { get; set; }
        public string ScheduleStatus { get; set; }
        public string TreatmentType { get; set; }
        public int TtId { get; set; }
        public string ColorCode { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public int CustomerScheduleId { get; set; }
        public string CustomerId { get; set; }
        public int TreatmentDuration { get; set; }
    }
}
