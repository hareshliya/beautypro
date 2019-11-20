using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class SchedulersResponse
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }

    public class Schedule
    {
        public string ClientName { get; set; }
        public string ScheduleStatus { get; set; }
        public string TreatmentType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
