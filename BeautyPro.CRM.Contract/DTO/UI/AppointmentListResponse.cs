using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Contract.DTO.UI
{
    public class AppointmentListResponse
    {
        public string Client { get; set; }
        public string Treatment { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public int Duration { get; set; }
        public string Therapist { get; set; }
        public decimal Price { get; set; }
        public int departmentId { get; set; }
    }
}
