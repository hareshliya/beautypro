using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Constants;
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


        public CustomerScheduleService(ICustomerScheduleRepository customerScheduleRepository,
                                       IEmployeeDetailRepository employeeDetailRepository,
                                       ICustomerScheduleTreatmentRepository customerScheduleTreatmentRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
            _employeeDetailRepository = employeeDetailRepository;
            _customerScheduleTreatmentRepository = customerScheduleTreatmentRepository;
        }

        public void AddEditAppointment(NewAppointmentRequest request, int userId, int branchId)
        {
            if (request.CsId != 0)
            {
                EditAppointment(request, userId, branchId);
            }
            else
            {
                AddAppointment(request, userId, branchId);
            }

            
        }

        private void AddAppointment(NewAppointmentRequest request, int userId, int branchId)
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
                Status = AppoinmentConstant.PENDING,
                DepartmentId = request.DepartmentId,
                BranchId = branchId,
                EnteredBy = userId,
                EnteredDate = DateTime.Now,
                CustomerScheduleTreatments = treatments,
            };

            _customerScheduleRepository.Add(customerSchedule);
            _customerScheduleRepository.SaveChanges();
        }

        private void EditAppointment(NewAppointmentRequest request, int userId, int branchId)
        {
            var schedule = _customerScheduleRepository.All.Where(x => x.Csid == request.CsId)
                .Include(c => c.CustomerScheduleTreatments).FirstOrDefault();

            if (schedule != null)
            {
                foreach (var treatment in schedule.CustomerScheduleTreatments)
                {
                    var updatedTreatment = request.Treatments.Where(c => c.Ttid == treatment.Ttid).FirstOrDefault();

                    if (treatment != null && updatedTreatment != null)
                    {
                        treatment.Empno = updatedTreatment.EmpNo;
                        treatment.StartTime = updatedTreatment.StartTime;
                        treatment.EndTime = updatedTreatment.EndTime;
                        treatment.Qty = updatedTreatment.Qty;
                    }
                }

                schedule.BookedDate = request.BookedDate;
                schedule.Status = request.Status;
                schedule.BranchId = request.BranchId;
                schedule.CustomerId = request.CustomerId;
                schedule.BranchId = branchId;
                schedule.DepartmentId = request.DepartmentId;
                schedule.ModifiedBy = userId;
                schedule.ModifiedDate = DateTime.Now;

                _customerScheduleRepository.SaveChanges();
            }
            
        }

        public void DeleteAppointment(int csid, int userId)
        {
            var schedule = _customerScheduleRepository
                .FirstOrDefault(x => x.Csid == csid);

            if (schedule != null)
            {
                schedule.DeletedBy = userId;
                schedule.DeletedDate = DateTime.Now;

                _customerScheduleRepository.SaveChanges();
            }

        }

        public List<EmployeeDetailDTO> GetFilteredEmployees(EmployeeRosterRequest request)
        {
            var employees = _employeeDetailRepository.All
            .Where(x => !x.IsDeleted && x.DeletedBy == null);

            if (request.departmentId != 0)
            {
                employees = employees
                    .Include(x => x.EmployeeRosters)
                    .Where(x => x.DepartmentId == request.departmentId
                    && x.DeletedBy == null && x.DeletedDate == null
                    && x.EmployeeRosters.Any(l => l.WorkingDate == request.Date));
            }
            return DomainDTOMapper.ToEmployeeDetailDTOs(employees.ToList());
        }

        //public IList<SchedulersResponse> GetShedules(ScheduleRequest request)
        //{
        //    var result = _customerScheduleTreatmentRepository
        //        .All
        //        .Include(c => c.CustomerSchedule).ThenInclude(x => x.Customer)
        //        .Include(c => c.Tt)
        //        .Include(c => c.Employee).ThenInclude(c => c.EmployeeRosters)
        //        .Include(c => c.Employee).ThenInclude(c => c.Designation)
        //        // .Where(x => x.Employee.EmployeeRosters.Any(l => l.WorkingDate == request.WorkingDate))
        //        .Where(x => x.CustomerSchedule.BranchId == request.BranchId && 
        //        (x.CustomerSchedule.DepartmentId == request.DepartmentId || request.DepartmentId == 0) 
        //        && x.CustomerSchedule.Status == "New")
        //        .Select(v => new { 
        //        Therapist = v.Employee.Name,
        //        Designation = v.Employee.Designation.Name,
        //        Schedules = v
        //    }).ToList();

        //    return result.GroupBy(p => new { p.Therapist, p.Designation }, p => p.Schedules, (key, g) => new SchedulersResponse()
        //    {
        //        EmployeeName = key.Therapist,
        //        Designation = key.Designation,
        //        Schedules = DomainDTOMapper.ToSchedule(g)
        //    }).ToList();
        //}

        public IList<SchedulersResponse> GetShedules(ScheduleRequest request)
        {
            var result = _customerScheduleTreatmentRepository
                .All
                .Include(c => c.CustomerSchedule).ThenInclude(x => x.Customer)
                .Include(c => c.Tt)
                .Include(c => c.Employee).ThenInclude(c => c.EmployeeRosters)
                .Include(c => c.Employee).ThenInclude(c => c.Designation)
                .Where(x => x.Employee.EmployeeRosters.Any(l => l.WorkingDate == request.WorkingDate))
                .Where(x => x.CustomerSchedule.BranchId == request.BranchId && x.CustomerSchedule.BookedDate == request.WorkingDate &&
                (x.CustomerSchedule.DepartmentId == request.DepartmentId || request.DepartmentId == 0)
                && x.CustomerSchedule.Status != AppoinmentConstant.CANCELLED)
                .Where(c => c.CustomerSchedule.DeletedBy == null && c.CustomerSchedule.DeletedDate == null)
                .Select(v => new {
                    EmpNo = v.Employee.Empno,
                    Therapist = v.Employee.Name,
                    Designation = v.Employee.Designation.Name,
                    Schedules = v
                }).ToList();

            var allEmployees = _employeeDetailRepository.All
                .Include(c => c.EmployeeRosters)
                .Where(x => x.EmployeeRosters.Any(l => l.WorkingDate == request.WorkingDate) && (x.DepartmentId == request.DepartmentId || request.DepartmentId == 0))
                .Where(c => c.DeletedBy == null && c.DeletedBy == null)
                .Select(c => new SchedulersResponse()
                {
                    EmpNo = c.Empno,
                    Designation = c.Designation.Name,
                    EmployeeName = c.Name,
                }).ToList();

            var employeesWithSchedules = result.GroupBy(p => new { p.Therapist, p.Designation, p.EmpNo }, p => p.Schedules, (key, g) => new SchedulersResponse()
            {
                EmpNo = key.EmpNo,
                EmployeeName = key.Therapist,
                Designation = key.Designation,
                Schedules = DomainDTOMapper.ToSchedule(g)
            }).ToList();

            if (employeesWithSchedules.Count == 0)
            {
                return allEmployees;
            }

            var tempEmployeesWithSchedules = employeesWithSchedules;

            foreach (var emp in allEmployees)
            {
                if (!tempEmployeesWithSchedules.Any(c => c.EmpNo == emp.EmpNo))
                {
                    employeesWithSchedules.Add(emp);
                }
            }

            return employeesWithSchedules;
        }

        public void UpdateAppoinmentStatus(AppoinmentStatusRequest request, int userId)
        {
            var schedule = _customerScheduleRepository.FirstOrDefault(x => x.Csid == request.CsId);

            if (schedule != null)
            {
                schedule.Status = request.Status;
                schedule.ModifiedDate = DateTime.Now;
                schedule.ModifiedBy = userId;
            }

            _customerScheduleRepository.SaveChanges();

        }

    }
}
