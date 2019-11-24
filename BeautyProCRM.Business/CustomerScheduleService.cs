using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public readonly ICustomerScheduleTreatmentRepository _customerScheduleTreatmentRepository;
        private const string NEW = "New";

        public CustomerScheduleService(ICustomerScheduleRepository customerScheduleRepository,
                                       IEmployeeDetailRepository employeeDetailRepository,
                                       ICustomerScheduleTreatmentRepository customerScheduleTreatmentRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
            _employeeDetailRepository = employeeDetailRepository;
            _customerScheduleTreatmentRepository = customerScheduleTreatmentRepository;
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
                    StartTime = treatment.StartTime,
                    EndTime = treatment.EndTime,
                    Qty = treatment.Qty
                });
            }

            var customerSchedule = new CustomerSchedule()
            {
                CustomerId = request.CustomerId,
                BookedDate = request.BookedDate,
                Status = NEW,
                DepartmentId = request.DepartmentId,
                BranchId = request.BranchId,
                EnteredBy = request.EnteredBy,
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

        public IList<SchedulersResponse> GetShedules(ScheduleRequest request)
        {
            var result = _customerScheduleTreatmentRepository
                .All
                .Include(c => c.CustomerSchedule).ThenInclude(x => x.Customer)
                .Include(c => c.Tt)
                .Include(c => c.Employee).ThenInclude(c => c.EmployeeRosters)
                .Include(c => c.Employee).ThenInclude(c => c.Designation)
                // .Where(x => x.Employee.EmployeeRosters.Any(l => l.WorkingDate == request.WorkingDate))
                .Where(x => x.CustomerSchedule.BranchId == request.BranchId && 
                (x.CustomerSchedule.DepartmentId == request.DepartmentId || request.DepartmentId == 0) 
                && x.CustomerSchedule.Status == "New")
                .Select(v => new { 
                Therapist = v.Employee.Name,
                Designation = v.Employee.Designation.Name,
                Schedules = v
            }).ToList();

            return result.GroupBy(p => new { p.Therapist, p.Designation }, p => p.Schedules, (key, g) => new SchedulersResponse()
            {
                EmployeeName = key.Therapist,
                Designation = key.Designation,
                Schedules = DomainDTOMapper.ToSchedule(g)
            }).ToList();
        }
    }
}
