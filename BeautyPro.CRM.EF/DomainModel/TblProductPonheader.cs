using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductPonheader
    {
        public string Pono { get; set; }
        public int SupplierId { get; set; }
        public DateTime? Podate { get; set; }
        public bool? IsCach { get; set; }
        public string Remarks { get; set; }
        public DateTime? SysDate { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? IsDelete { get; set; }
        public int? IsDeletedBy { get; set; }
        public int? BranchId { get; set; }
        public bool? IsPurchased { get; set; }
    }
}
