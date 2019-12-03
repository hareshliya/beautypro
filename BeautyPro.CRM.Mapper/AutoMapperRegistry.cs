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

            cfg.CreateMap<CustomerScheduleTreatment, InvoiceTreatmentResponse>()
                .ForMember(c => c.EmployeeName, m => m.MapFrom(x => x.Employee.Name))
                .ForMember(c => c.EmployeeNo, m => m.MapFrom(x => x.Empno))
                .ForMember(c => c.Amount, m => m.MapFrom(x => x.Tt.Price * x.Qty))
                .ForMember(c => c.Quantity, m => m.MapFrom(x => x.Qty))
                .ForMember(c => c.Price, m => m.MapFrom(x => x.Tt.Price))
                .ForMember(c => c.TreatmentName, m => m.MapFrom(x => x.Tt.Ttname));

            cfg.CreateMap<Product, ProductDTO>()
                .ForMember(c => c.SellingPrice, m => m.MapFrom(x => x.ProductSellingPrice.SellingPrice));

            cfg.CreateMap<CustomerScheduleTreatment, AppointmentTreatment>()
                .ForMember(c => c.Ttid, m => m.MapFrom(x => x.Ttid))
                .ForMember(c => c.EmpNo, m => m.MapFrom(x => x.Empno))
                .ForMember(c => c.StartTime, m => m.MapFrom(x => x.StartTime))
                .ForMember(c => c.EndTime, m => m.MapFrom(x => x.EndTime))
                .ForMember(c => c.Qty, m => m.MapFrom(x => x.Qty));

           

            cfg.CreateMap<CustomerInvoiceHeader, InvoiceDTO>()
                .ForMember(c => c.InvoiceNo, m => m.MapFrom(x => x.InvoiceNo))
                .ForMember(c => c.CustomeFullName, m => m.MapFrom(x => x.Customer.FullName))
                .ForMember(c => c.InvoiceDate, m => m.MapFrom(x => x.InvDateTime.Date))
                .ForMember(c => c.Tax, m => m.MapFrom(x => x.ProductTaxAmount + x.TreatmentTaxAmount))
                .ForMember(c => c.SubTotal, m => m.MapFrom(x => x.TreatmentSubTotalAmount + x.ProductSubTotalAmount))
                .ForMember(c => c.Discount, m => m.MapFrom(x => x.TreatmentDiscountAmount))
                .ForMember(c => c.DueAmount, m => m.MapFrom(x => x.ProductDueAmount + x.TreatmentDueAmount))
                .ForMember(c => c.InvoiceTreatments, m => m.MapFrom(x => x.CustomerInvoiceTreatments))
                .ForMember(c => c.InvoiceProducts, m => m.MapFrom(x => x.CustomerInvoiceProducts));

            cfg.CreateMap<CustomerInvoiceTreatment, InvoiceTreatmentDTO>()
                .ForMember(c => c.TreatmentTypeName, m => m.MapFrom(c => c.Tt.Ttname))
                .ForMember(c => c.EmployeeName, m => m.MapFrom(c => c.EmpnoNavigation.Name));

            cfg.CreateMap<CustomerInvoiceProducts, InvoiceProductDTO>()
                .ForMember(c => c.RecomendedBy, m => m.MapFrom(c => c.EmpnoNavigation.Name));
        }
    }
}
