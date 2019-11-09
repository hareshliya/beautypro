using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductGrndetails
    {
        public string Grnno { get; set; }
        public string ItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Remarks { get; set; }
        public decimal? PriceVarianceValue { get; set; }
    }
}
