using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblMastProductCategory
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string Description { get; set; }
        public int? BranchId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
