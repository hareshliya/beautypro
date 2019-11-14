using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public List<CustomerDTO> SearchCustomer(CustomerSearchRequest request)
        {
            var customers = _customerRepository.All;

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                customers = customers.Where(c => c.FullName.Contains(request.SearchText));
            }

            return DomainDTOMapper.ToCustomerDTOs(customers.ToList());
        }

        public void AddNewCustomer(NewCustomerRequest request)
        {
            var customerNo = String.Format("C{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            _customerRepository.Add(DomainDTOMapper.ToCustomerDomain(new CustomerDTO()
            {
                CustomerId = customerNo,
                Address = request.Address,  
                FullName = request.Name,
                Gender = request.Gender,
                EnteredDate = DateTime.Now,
                LoyaltyCardNo = request.LoyaltyCardNo,
                Email = request.Email,
                MobileNo = request.ContactNo,
                EnteredBy = 1,
                BranchId = 1
            }));

            _customerRepository.SaveChanges();
        }
    }
}
