using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductSrndetails
    {
        public string Srnno { get; set; }
        public string ItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal? Qry { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
