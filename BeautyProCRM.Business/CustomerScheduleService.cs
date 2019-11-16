using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerScheduleService : ICustomerScheduleService
    {
        private readonly ICustomerScheduleRepository _customerScheduleRepository;
        private readonly IEmployeeDetailRepository _employeeDetailRepository;
        private const string NEW = "New";

        public CustomerScheduleService(ICustomerScheduleRepository customerScheduleRepository,
                                       IEmployeeDetailRepository employeeDetailRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
            _employeeDetailRepository = employeeDetailRepository;
        }

        public void AddNewAppointment(NewAppointmentRequest request)
        {
            var treatments = new List<CustomerScheduleTreatment>();

            foreach (var treatment in request.Treatments)
            {
                treatments.Add(new CustomerScheduleTreatment()
                {
                    Ttid = treatment.Ttid,
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

        public List<EmployeeDetailDTO> GetFilteredEmployees(int departmentId)
        {
            var employees = _employeeDetailRepository.All
            .Where(x => !x.IsDeleted && x.DeletedBy == null);

            if (departmentId != 0)
            {
                employees = employees.Where(x => x.DepartmentId == departmentId);
            }
            return DomainDTOMapper.ToEmployeeDetailDTOs(employees.ToList());
        }
    }
}
