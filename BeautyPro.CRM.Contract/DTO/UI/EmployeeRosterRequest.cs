using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class EmployeeRosterRequest
    {
        public int DepartmentId { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}
