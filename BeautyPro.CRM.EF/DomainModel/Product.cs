using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Product")]
    public partial class Product
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public decimal? MaxQty { get; set; }
        public decimal? MinQty { get; set; }
        public decimal? LeadTime { get; set; }
        public decimal? ReOrderLevel { get; set; }
        public decimal? ReOrderQty { get; set; }
        public int? UnitId { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public int? BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public string Barcode { get; set; }

        [ForeignKey("ProductSellingPrice")]
        [Column(TypeName = "char(4)")]
        public string ProductSellingPriceItemId { get; set; }
        public virtual ProductSellingPrice ProductSellingPrice { get; set; }
    }
}
