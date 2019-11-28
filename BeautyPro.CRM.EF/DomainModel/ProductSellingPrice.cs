using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_ProductSellingPrice")]
    public partial class ProductSellingPrice
    {
        public string ItemId { get; set; }
        public decimal? SellingPrice { get; set; }
    }
}
