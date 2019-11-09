using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.EF.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Mapper
{
    public static class DomainDTOMapper
    {
        public static List<TreatmentTypeDTO> ToTreatmentTypesDTOs(List<TreatmentType> treatments)
        {
            return AutoMapper.Mapper.Map<List<TreatmentType>, List<TreatmentTypeDTO>>(treatments);
        }

        public static TreatmentTypeDTO ToTreatmentTypesDTO(TreatmentType treatment)
        {
            return AutoMapper.Mapper.Map<TreatmentType, TreatmentTypeDTO>(treatment);
        }

        public static TreatmentType ToTreatmentTypeDomain(TreatmentTypeDTO treatmentTypeDTO)
        {
            return AutoMapper.Mapper.Map<TreatmentTypeDTO, TreatmentType>(treatmentTypeDTO);
        }

        public static DepartmentDTO ToDepartmentDTO(Department department)
        {
            return AutoMapper.Mapper.Map<Department, DepartmentDTO>(department);
        }

        public static List<DepartmentDTO> ToDepartmentDTOs(List<Department> departments)
        {
            return AutoMapper.Mapper.Map<List<Department>, List<DepartmentDTO>>(departments);
        }

        public static List<CustomerGiftVoucherDTO> ToCustomerGiftVoucherDTOs(List<CustomerGiftVoucher> giftVoucher)
        {
            return AutoMapper.Mapper.Map<List<CustomerGiftVoucher>, List<CustomerGiftVoucherDTO>>(giftVoucher);
        }

        public static CustomerGiftVoucher ToCustomerGiftVoucherDomain(CustomerGiftVoucherDTO voucher)
        {
            return AutoMapper.Mapper.Map<CustomerGiftVoucherDTO, CustomerGiftVoucher>(voucher);
        }

    }
}
