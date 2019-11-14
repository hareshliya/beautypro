using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerScheduleService
    {
        void AddNewAppointment(NewAppointmentRequest request);
    }
}
