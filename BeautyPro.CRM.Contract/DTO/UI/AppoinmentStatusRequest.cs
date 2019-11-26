using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class AppoinmentStatusRequest
    {
        public int CsId { get; set; }
        public string Status { get; set; }
    }
}
