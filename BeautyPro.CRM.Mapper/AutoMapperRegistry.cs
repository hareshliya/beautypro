using AutoMapper;
using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
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

            cfg.CreateMap<CustomerGiftVoucher, CustomerGiftVoucherDTO>()
                .ForMember(data => data.CustomerName, opt => opt.MapFrom(x => x.Customer.FullName));

            cfg.CreateMap<CustomerGiftVoucherDTO, CustomerGiftVoucher>()
               .ForMember(c => c.Customer, m => m.Ignore())
               .ForMember(c => c.Department, m => m.Ignore())
               .ForMember(c => c.Pt, m => m.Ignore())
               .ForMember(c => c.Tt, m => m.Ignore());

            cfg.CreateMap<CustomerScheduleTreatment, Schedule>()
                .ForMember(c => c.ClientName, m => m.MapFrom(x => x.CustomerSchedule.Customer.FullName))
                .ForMember(c => c.TreatmentType, m => m.MapFrom(x => x.Tt.Ttname))
                .ForMember(c => c.ScheduleStatus, m => m.MapFrom(x => x.CustomerSchedule.Status))
                .ForMember(c => c.StartTime, m => m.MapFrom(x => x.StartTime))
                .ForMember(c => c.EndTime, m => m.MapFrom(x => x.EndTime));
        }
    }
}
