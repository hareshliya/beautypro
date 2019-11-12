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
        TreatmentTypeDTO AddNewTreatment(TreatmentTypeDTO treatment);
        List<TreatmentTypeDTO> GetFilteredTreatments(TreatmentFilterRequest request);
    }
}
