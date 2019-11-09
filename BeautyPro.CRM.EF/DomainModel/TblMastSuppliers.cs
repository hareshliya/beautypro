using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblMastSuppliers
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonTelNo { get; set; }
        public int? BranchId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
