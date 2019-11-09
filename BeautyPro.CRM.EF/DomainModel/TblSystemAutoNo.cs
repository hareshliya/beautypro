using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblSystemAutoNo
    {
        public string FormType { get; set; }
        public int AutoNum { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public TimeSpan? LastModifiedTime { get; set; }
        public bool? IsDateUpdated { get; set; }
        public bool? IsMorningUpdated { get; set; }
        public bool? IsEveningUpdated { get; set; }
    }
}
