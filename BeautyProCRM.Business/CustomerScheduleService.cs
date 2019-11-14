using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerScheduleService : ICustomerScheduleService
    {
        private readonly ICustomerScheduleRepository _customerScheduleRepository;
        private const string NEW = "New";

        public CustomerScheduleService(ICustomerScheduleRepository customerScheduleRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
        }

        public void AddNewAppointment(NewAppointmentRequest request)
        {
            var treatments = new List<CustomerScheduleTreatment>();

            foreach (var treatment in request.Treatments)
            {
                treatments.Add(new CustomerScheduleTreatment()
                {
                    Ttid = treatment.TreatmentTypeId,
                    Empno = treatment.EmpNo,
                    StartTime = treatment.StartTime.TimeOfDay,
                    EndTime = treatment.StartTime.AddMinutes(treatment.Duration).TimeOfDay
                });
            }

            var customerSchedule = new CustomerSchedule()
            {
                CustomerId = request.CustomerId,
                BookedDate = DateTime.Now,
                Status = NEW,
                DepartmentId = request.DepartmentId,
                BranchId = request.BranchId,
                EnteredBy = 2,
                EnteredDate = DateTime.Now,
                CustomerScheduleTreatments = treatments
            };

            _customerScheduleRepository.Add(customerSchedule);
            _customerScheduleRepository.SaveChanges();
        }
    }
}
