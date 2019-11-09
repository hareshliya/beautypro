using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblConfig
    {
        public int ConfigId { get; set; }
        public decimal AbsentDeductionRatio { get; set; }
        public decimal PresentAllawancesRatio { get; set; }
    }
}
