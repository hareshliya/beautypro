using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class AppointmentListResponse
    {
        public int CsId { get; set; }
        public string Client { get; set; }
        public string CustomerId { get; set; }
        public string Treatment { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Duration { get; set; }
        public string Therapist { get; set; }
        public decimal Price { get; set; }
        public int departmentId { get; set; }
        public string Status { get; set; }
        public List<AppointmentTreatment> Treatments { get; set; }
    }
}
