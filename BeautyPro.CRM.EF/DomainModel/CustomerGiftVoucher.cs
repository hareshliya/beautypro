using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerGiftVoucher")]
    public partial class CustomerGiftVoucher
    {
        public string GvinvoiceNo { get; set; }
        public string VoucherNo { get; set; }
        public string CustomerId { get; set; }
        public string TransType { get; set; }
        public DateTime InvDateTime { get; set; }
        public int BranchId { get; set; }
        public int? Ttid { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DueAmount { get; set; }
        public int? DepartmentId { get; set; }
        public int Ptid { get; set; }
        public bool IsRedeem { get; set; }
        public bool IsCanceled { get; set; }
        public string CancelReason { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CanceledBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CanceledDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Department Department { get; set; }
        public virtual PaymentType Pt { get; set; }
        public virtual TreatmentType Tt { get; set; }

        [NotMapped]
        public string IssuedBy { get; set; }
    }
}
