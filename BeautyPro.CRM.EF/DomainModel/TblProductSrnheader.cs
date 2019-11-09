using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductSrnheader
    {
        public string Srnno { get; set; }
        public string Grnno { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierInvoiceNo { get; set; }
        public DateTime? SupplierInvoiceDate { get; set; }
        public DateTime? Srndate { get; set; }
        public bool? IsCash { get; set; }
        public DateTime? SysDate { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? UserId { get; set; }
        public bool? IsDelete { get; set; }
        public int? IsDeletedBy { get; set; }
        public int? BranchId { get; set; }
    }
}
