using AutoMapper;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.EF.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.Mapper
{
    public class AutoMapperRegistry
    {
        public static void CreateMappings()
        {
            try
            {
                AutoMapper.Mapper.Initialize(cfg =>
                {
                    CreateMappings(cfg);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void CreateMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TreatmentType, TreatmentTypeDTO>()
                .ForMember(data => data.Department, opt => opt.MapFrom(x => x.Department.Name));

            cfg.CreateMap<TreatmentTypeDTO, TreatmentType>();

            cfg.CreateMap<Department, DepartmentDTO>();
            cfg.CreateMap<DepartmentDTO, Department>();

            cfg.CreateMap<Customer, CustomerDTO>();
            cfg.CreateMap<CustomerDTO, Customer>();
        }
    }
}
