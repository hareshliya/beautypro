using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Mast_CreditCardType")]
    public class CreditCardType
    {
        [Key]
        public int CCTId { get; set; }
        public string Name { get; set; }
    }
}
