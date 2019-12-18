using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_CustomerInvoiceHeader")]
    public partial class CustomerInvoiceHeader
    {
        public CustomerInvoiceHeader()
        {
            CustomerInvoiceProducts = new HashSet<CustomerInvoiceProducts>();
            CustomerInvoiceTreatments = new HashSet<CustomerInvoiceTreatment>();
        }

        public string InvoiceNo { get; set; }

        [ForeignKey("Customer")]
        [Column(TypeName = "char(10)")]
        public string CustomerId { get; set; }
        public DateTime InvDateTime { get; set; }
        public int BranchId { get; set; }
        public string TransType { get; set; }
        public int Ptid { get; set; }
        public int? CCTId { get; set; }

        //public decimal SubTotalAmount { get; set; }
        //public decimal DiscountAmount { get; set; }
        //public decimal TaxAmount { get; set; }
        //public decimal DueAmount { get; set; }

        public decimal TreatmentSubTotalAmount { get; set; }
        public decimal TreatmentDiscountAmount { get; set; }
        public decimal TreatmentTaxAmount { get; set; }
        public decimal TreatmentDueAmount { get; set; }

        public decimal ProductSubTotalAmount { get; set; }
        public decimal ProductTaxAmount { get; set; }
        public decimal ProductDueAmount { get; set; }

        public int DepartmentId { get; set; }
        public string GvinvoiceNo { get; set; }
        //public bool IsCanceled { get; set; }
        public int Status { get; set; }
        public string CancelReason { get; set; }
        public bool? IsAmended { get; set; }
        public string AmendedReason { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? CanceledBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CanceledDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Department Department { get; set; }
        public virtual PaymentType Pt { get; set; }
        public virtual CreditCardType CreditCardType { get; set; }
        public virtual ICollection<CustomerInvoiceProducts> CustomerInvoiceProducts { get; set; } = new List<CustomerInvoiceProducts>();
        public virtual ICollection<CustomerInvoiceTreatment> CustomerInvoiceTreatments { get; set; }
    }
}
