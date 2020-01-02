using BeautyPro.CRM.Contract.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class VoucherRequest
    {
        public VoucherStatus Status { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentId { get; set; }
    }

    public class IssuedVoucherRequest
    {
        public string CustomerId { get; set; }
    }
}
