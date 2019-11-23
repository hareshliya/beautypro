using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Mast_PaymentType")]
    public partial class PaymentType
    {
        public PaymentType()
        {
            TblCustomerGiftVoucher = new HashSet<CustomerGiftVoucher>();
            TblCustomerInvoiceHeader = new HashSet<CustomerInvoiceHeader>();
        }

        public int Ptid { get; set; }
        public string Ptname { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<CustomerGiftVoucher> TblCustomerGiftVoucher { get; set; }
        public virtual ICollection<CustomerInvoiceHeader> TblCustomerInvoiceHeader { get; set; }
    }
}
