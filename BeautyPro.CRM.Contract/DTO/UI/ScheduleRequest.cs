using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class ScheduleRequest
    {
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime WorkingDate { get; set; }
    }
}
