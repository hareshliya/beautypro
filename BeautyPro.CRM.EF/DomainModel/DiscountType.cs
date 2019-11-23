using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Mast_DiscountType")]
    public class DiscountType
    {
        [Key]
        public int DTId { get; set; }
        public decimal Discount { get; set; }
    }
}
