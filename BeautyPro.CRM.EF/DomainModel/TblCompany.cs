using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblBranch = new HashSet<Branch>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Branch> TblBranch { get; set; }
    }
}
