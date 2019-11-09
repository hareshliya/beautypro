using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductPondetails
    {
        public string Pono { get; set; }
        public string ItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Remarks { get; set; }
    }
}
