using System;
using System.Collections.Generic;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class TblMastPaymentType
    {
        public TblMastPaymentType()
        {
            TblCustomerGiftVoucher = new HashSet<CustomerGiftVoucher>();
            TblCustomerInvoiceHeader = new HashSet<TblCustomerInvoiceHeader>();
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
        public virtual ICollection<TblCustomerInvoiceHeader> TblCustomerInvoiceHeader { get; set; }
    }
}
