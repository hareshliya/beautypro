using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
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

        public static List<CustomerDTO> ToCustomerDTOs(List<Customer> customers)
        {
            return AutoMapper.Mapper.Map<List<Customer>, List<CustomerDTO>>(customers);
        }

        public static CustomerDTO ToCustomerDTO(Customer customer)
        {
            return AutoMapper.Mapper.Map<Customer, CustomerDTO>(customer);
        }

        public static Customer ToCustomerDomain(CustomerDTO customer)
        {
            return AutoMapper.Mapper.Map<CustomerDTO, Customer>(customer);
        }
        
        public static List<PaymentTypeDTO> ToPaymentTypeDTOs(List<PaymentType> paymentTypes)
        {
            return AutoMapper.Mapper.Map<List<PaymentType>, List<PaymentTypeDTO>>(paymentTypes);
        }

        public static List<EmployeeDetailDTO> ToEmployeeDetailDTOs(List<EmployeeDetail> employeeDetail)
        {
            return AutoMapper.Mapper.Map<List<EmployeeDetail>, List<EmployeeDetailDTO>>(employeeDetail);
        }

        public static EmployeeDetail ToEmployeeDetailDomain(EmployeeDetailDTO employeeDetail)
        {
            return AutoMapper.Mapper.Map<EmployeeDetailDTO, EmployeeDetail>(employeeDetail);
        }

        public static IList<Schedule> ToSchedule(IEnumerable<CustomerScheduleTreatment> treatment)
        {
            return AutoMapper.Mapper.Map<IEnumerable<CustomerScheduleTreatment>, IList<Schedule>>(treatment);
        }

        public static List<InvoiceTreatmentResponse> ToInvoiceTreatmentResponse(List<CustomerScheduleTreatment> schedules)
        {
            return AutoMapper.Mapper.Map<List<CustomerScheduleTreatment>, List<InvoiceTreatmentResponse>>(schedules);
        }

        public static List<ProductDTO> ToProductDTOs(List<Product> products)
        {
            return AutoMapper.Mapper.Map<List<Product>, List<ProductDTO>>(products);
        }

    }
}
