using BeautyProCRM.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class AppointmentFilterRequest
    {
        public int? DepartmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime BookedDate { get; set; }
    }
}
