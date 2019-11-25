using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class VoucherDeleteRequest
    {
        public string GvinvoiceNo { get; set; }
        public string CancelReason { get; set; }
    }
}
