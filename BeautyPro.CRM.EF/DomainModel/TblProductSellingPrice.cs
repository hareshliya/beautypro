using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblProductSellingPrice
    {
        public string ItemId { get; set; }
        public decimal? SellingPrice { get; set; }
    }
}
