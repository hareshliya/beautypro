using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductGrnheader
    {
        public string Grnno { get; set; }
        public int SupplierId { get; set; }
        public string SupplierInvoiceNo { get; set; }
        public DateTime? Grndate { get; set; }
        public DateTime? SupplierIvoiceDate { get; set; }
        public bool? IsCach { get; set; }
        public string Remarks { get; set; }
        public DateTime? SysDate { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? IsDelete { get; set; }
        public int? IsDeletedBy { get; set; }
        public int? BranchId { get; set; }
        public string Pono { get; set; }
    }
}
