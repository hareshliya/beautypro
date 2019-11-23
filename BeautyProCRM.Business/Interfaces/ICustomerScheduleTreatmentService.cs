using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerScheduleTreatmentService
    {
        List<AppointmentListResponse> GetFilteredAppointments(AppointmentFilterRequest request);
        List<InvoiceTreatmentResponse> GetInvoiceableScheduledTreatments(InvoiceTreatmentRequest request);
    }
}
