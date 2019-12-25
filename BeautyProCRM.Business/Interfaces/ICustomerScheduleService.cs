using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerScheduleService
    {
        void AddEditAppointment(NewAppointmentRequest request, int userId, int branchId);
        List<EmployeeDetailDTO> GetFilteredEmployees(EmployeeRosterRequest request);
        IList<SchedulersResponse> GetShedules(ScheduleRequest request);
        void DeleteAppointment(int csid, int userId);
        void UpdateAppoinmentStatus(AppoinmentStatusRequest request, int userId);
    }
}
