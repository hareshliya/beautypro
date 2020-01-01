using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceSaveRequest
    {
        public string CustomerId { get; set; }
        public int DepartmentId { get; set; }
        public int? CreditCardTypeId { get; set; }
        public string TransType { get; set; }

        public string GvinvoiceNo { get; set; }
        public decimal GVRedeemedAmount { get; set; }

        public decimal TreatmentSubTotal  { get; set; }
        public decimal TreatmentDueAmount { get; set; }
        public decimal TreatmentsTaxAmount { get; set; }
        public decimal ProductSubTotal { get; set; }
        public decimal ProductDueAmount { get; set; }
        public decimal ProductsTaxAmount { get; set; }
        public decimal TreatmentDiscountAmount { get; set; }

        public List<InvoiceableTreatment> Treatments { get; set; }
        public List<InvoiceableProduct> Products { get; set; }
        //public decimal TreatmentDiscount { get; set; }
    }

    public class InvoiceableTreatment
    {
        public int CustomerScheduleTreatmentId { get; set; }
        public int TreatmentTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int EmployeeNo { get; set; }
    }

    public class InvoiceableProduct
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int RecomendedBy { get; set; }
    }
}
