using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Constants;
using BeautyProCRM.Business.Interfaces;
using BeautyProCRM.Common.Enum;
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
        private const string PENDING = "Pending";
        private const string CONFIRMED = "confirmed";
        private const string CANCELLED = "Cancelled";


        public CustomerScheduleTreatmentService(ICustomerScheduleTreatmentRepository customerScheduleTreatmentRepository)
        {
            _customerScheduleTreatmentRepository = customerScheduleTreatmentRepository;
        }

        public List<AppointmentListResponse> GetFilteredAppointments(AppointmentFilterRequest request)
        {

            string status = GetAppointmentStatus(request.Status);

            var appointments = _customerScheduleTreatmentRepository.All
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Customer)
                .Include(x => x.CustomerSchedule).ThenInclude(c => c.Department)
                .Include(c => c.Employee)
                .Include(c => c.Tt)
                .Where(x => x.CustomerSchedule.DeletedBy == null && x.CustomerSchedule.DeletedDate == null
                    && x.CustomerSchedule.BookedDate.Date == request.BookedDate.Date
                    && (x.CustomerSchedule.Status == status || request.Status == AppointmentStatus.All))
                .Select(c => new AppointmentListResponse()
                {
                    CsId = c.Csid,
                    Client = c.CustomerSchedule.Customer.FullName,
                    CustomerId = c.CustomerSchedule.CustomerId,
                    Date = c.CustomerSchedule.BookedDate,
                    Duration = c.EndTime - c.StartTime,
                    Price = c.Tt.Price,
                    Therapist = c.Employee.Name,
                    Time = c.StartTime,
                    Treatment = c.Tt.Ttname,
                    departmentId = c.CustomerSchedule.DepartmentId,
                    Status = c.CustomerSchedule.Status,
                    Treatments = DomainDTOMapper.TOAppointmentTreatment(c.CustomerSchedule.CustomerScheduleTreatments)
                }).ToList();

            if (request.DepartmentId.HasValue && request.DepartmentId.Value > 0)
            {
                appointments = appointments.Where(x => x.departmentId == request.DepartmentId.Value).ToList();
            }

            return appointments;
        }

        public List<InvoiceTreatmentResponse> GetInvoiceableScheduledTreatments(InvoiceTreatmentRequest request)
        {
            var treatments = _customerScheduleTreatmentRepository
                            .All
                            .Include(c => c.CustomerSchedule)
                            .Include(c => c.Employee)
                            .Include(c => c.Tt)
                            .Where(x => x.CustomerSchedule.CustomerId == request.CustomerId
                                && (x.CustomerSchedule.DeletedBy == null && x.CustomerSchedule.DeletedDate == null)
                                && x.CustomerSchedule.Status == AppoinmentConstant.CONFIRMED
                                && x.CustomerSchedule.DepartmentId == request.DepartmentId
                                && x.CustomerSchedule.BookedDate == DateTime.Now.Date)          
                            .ToList();

            return DomainDTOMapper.ToInvoiceTreatmentResponse(treatments);
        }

        private string GetAppointmentStatus(AppointmentStatus status)
        {
            switch (status)
            {
                case AppointmentStatus.Cancelled: return CANCELLED;
                case AppointmentStatus.Confirmed: return CONFIRMED;
                case AppointmentStatus.Pending: return PENDING;
                default: return string.Empty;
            }
        }
    }
}
