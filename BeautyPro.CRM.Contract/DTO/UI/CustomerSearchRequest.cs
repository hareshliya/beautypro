using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class CustomerSearchRequest
    {
        public string SearchText { get; set; }
        public int DepartmentId { get; set; }
    }
}
