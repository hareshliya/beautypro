﻿using BeautyPro.CRM.Contract.DTO.UI;
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
        private readonly ICustomerScheduleTreatmentRepository _customerScheduleTreatmentRepository;

        public CustomerScheduleTreatmentService(ICustomerScheduleTreatmentRepository customerScheduleTreatmentRepository)
        {
            _customerScheduleTreatmentRepository = customerScheduleTreatmentRepository;
        }

        public List<AppointmentListResponse> GetFilteredAppointments(AppointmentFilterRequest request)
        {
            var appointments = _customerScheduleTreatmentRepository.All
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Customer)
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Department)
                .Include(c => c.EmpnoNavigation)
                .Include(c => c.Tt)
                .Where(x => x.CustomerSchedule.DeletedBy == null && x.CustomerSchedule.DeletedDate == null)
                .Select(c => new AppointmentListResponse()
                {
                    Client = c.CustomerSchedule.Customer.FullName,
                    Date = c.CustomerSchedule.BookedDate,
                    Duration = c.EndTime - c.StartTime,
                    Price = c.Tt.Price,
                    Therapist = c.EmpnoNavigation.Name,
                    Time = c.StartTime,
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
