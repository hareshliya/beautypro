using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ITreatmentService
    {
        List<TreatmentTypeDTO> GetTreatmentsForEmployee(TreatmentRequest request);
        List<DepartmentDTO> GetDepartments();
        void AddEditTreatment(TreatmentTypeDTO request, int userId, int branchId);
        List<TreatmentTypeDTO> GetFilteredTreatments(TreatmentFilterRequest request);
        void DeleteTreatment(int treatmentTypeId, int deletedBy);
    }
}
