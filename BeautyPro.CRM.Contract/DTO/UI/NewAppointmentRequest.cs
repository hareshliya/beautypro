﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class NewAppointmentRequest
    {
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
        public int TreatmentTypeId { get; set; }
        public int EmpNo { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
    }
}
