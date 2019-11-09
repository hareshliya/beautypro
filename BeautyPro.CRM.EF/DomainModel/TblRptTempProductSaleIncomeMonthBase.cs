using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblRptTempProductSaleIncomeMonthBase
    {
        public int AutoId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int? JanuaryCount { get; set; }
        public decimal? JanuaryIncome { get; set; }
        public int? FebruaryCount { get; set; }
        public decimal? FebruaryIncome { get; set; }
        public int? MarchCount { get; set; }
        public decimal? MarchIncome { get; set; }
        public int? AprilCount { get; set; }
        public decimal? AprilIncome { get; set; }
        public int? MayCount { get; set; }
        public decimal? MayIncome { get; set; }
        public int? JuneCount { get; set; }
        public decimal? JuneIncome { get; set; }
        public int? JulyCount { get; set; }
        public decimal? JulyIncome { get; set; }
    }
}
