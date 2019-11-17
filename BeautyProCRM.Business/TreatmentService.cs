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
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeDetailRepository _employeeDetailRepository;

        public TreatmentService(
            ITreatmentTypeRepository treatmentTypeRepository,
            IDepartmentRepository departmentRepository,
            IEmployeeDetailRepository employeeDetailRepository)
        {
            this._treatmentTypeRepository = treatmentTypeRepository;
            this._departmentRepository = departmentRepository;
            this._employeeDetailRepository = employeeDetailRepository;
        }

        public List<TreatmentTypeDTO> GetTreatmentsForEmployee(TreatmentRequest request)
        {
            var employee = _employeeDetailRepository
                .All
                .Include(c => c.Department)
                .ThenInclude(c => c.TreatmentTypes)
                .Where(c => c.DepartmentId == request.DepartmentId && c.Empno == request.EMPNo && !c.IsDeleted && c.DeletedBy == null)
                .FirstOrDefault();

            if (employee != null && employee.Department != null && employee.Department.TreatmentTypes != null)
            {
                return DomainDTOMapper.ToTreatmentTypesDTOs(employee.Department.TreatmentTypes.ToList());
            }

            return new List<TreatmentTypeDTO>();
            
        }

        public List<DepartmentDTO> GetDepartments()
        {
            var departments = _departmentRepository
                .All
                .Where(x => !x.IsDeleted && x.DeletedBy == null)
                .ToList();

            return DomainDTOMapper.ToDepartmentDTOs(departments);
        }

        public TreatmentTypeDTO AddNewTreatment(TreatmentTypeDTO treatment)
        {
            treatment.BranchId = 1;
            treatment.EnteredDate = DateTime.Now;
            _treatmentTypeRepository.Add(DomainDTOMapper.ToTreatmentTypeDomain(treatment));
            _treatmentTypeRepository.SaveChanges();

            return treatment;
        }

        public List<TreatmentTypeDTO> GetFilteredTreatments(TreatmentFilterRequest request)
        {
            var treatmentTypes = _treatmentTypeRepository
                .All.Include(c => c.Department)
                .ToList();

            if (request.DepartmentId.HasValue && request.DepartmentId.Value != 0)
            {
                treatmentTypes = treatmentTypes
                    .Where(x => x.DepartmentId == request.DepartmentId.Value)
                    .ToList();
            }

            return DomainDTOMapper.ToTreatmentTypesDTOs(treatmentTypes.ToList());
        }

        public void DeleteTreatment(int treatmentTypeId, int deletedBy)
        {
            var treatment = _treatmentTypeRepository
                .FirstOrDefault(x => x.Ttid == treatmentTypeId);

            if(treatment != null)
            {
                treatment.DeletedBy = deletedBy;
                treatment.DeletedDate = DateTime.Now;
                _treatmentTypeRepository.Remove(treatment);
                _treatmentTypeRepository.SaveChanges();
            }

        }
    }
}
