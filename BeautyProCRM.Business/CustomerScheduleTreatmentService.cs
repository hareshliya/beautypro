using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyProCRM.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerScheduleTreatmentService : ICustomerScheduleTreatmentService
    {
        private readonly ICustomerScheduleTreatmentRepository _customerScheduleRepository;

        public CustomerScheduleTreatmentService(ICustomerScheduleTreatmentRepository customerScheduleRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
        }

        public List<AppointmentListResponse> GetFilteredAppointments(AppointmentFilterRequest request)
        {
            var appointments = _customerScheduleRepository.All
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Customer)
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Department)
                .Include(c => c.EmpnoNavigation)
                .Include(c => c.Tt)
                .Where(x => x.CustomerSchedule.DeletedBy == null && x.CustomerSchedule.DeletedDate == null)
                .Select(c => new AppointmentListResponse()
                {
                    Client = c.CustomerSchedule.Customer.FullName,
                    Date = c.CustomerSchedule.BookedDate,
                    Duration = 0,
                    Price = c.Tt.Price,
                    Therapist = c.EmpnoNavigation.Name,
                    Time = c.CustomerSchedule.BookedDate.TimeOfDay.Minutes,
                    Treatment = c.Tt.Ttname,
                    departmentId = c.CustomerSchedule.DepartmentId
                }).ToList();

            if (request.DepartmentId.HasValue && request.DepartmentId.Value > 0)
            {
                appointments = appointments.Where(x => x.departmentId == request.DepartmentId.Value).ToList();
            }

            return appointments;
        }
    }
}
