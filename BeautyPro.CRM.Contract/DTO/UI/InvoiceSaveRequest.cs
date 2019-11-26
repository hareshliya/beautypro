using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class InvoiceSaveRequest
    {
        public string CustomerId { get; set; }
        public int DepartmentId { get; set; }
        public List<InvoiceableTreatment> Treatments { get; set; }
        public List<InvoiceableProduct> Products { get; set; }
        public decimal TreatmentDiscount { get; set; }
    }

    public class InvoiceableTreatment
    {
        public int CustomerScheduleTreatmentId { get; set; }
        public int TreatmentTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int EmployeeNo { get; set; }
    }

    public class InvoiceableProduct
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int RecomendedBy { get; set; }
    }
}
