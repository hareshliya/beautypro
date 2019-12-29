using BeautyPro.CRM.Contract.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class VoucherStatusRequest
    {
        public string GVInvoiceNo { get; set; }
        public VoucherStatus Status { get; set; }
    }
}
