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

        public CustomerDTO GetCustomer(string customerId)
        {
            return DomainDTOMapper.ToCustomerDTO(_customerRepository.FirstOrDefault(c => c.CustomerId == customerId));
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

        public void AddEditCustomer(NewCustomerRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.CustomerId))
            {
                EditCustomer(request);
            }
            else
            {
                AddCustomer(request);
            }
        }

        private void AddCustomer(NewCustomerRequest request)
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

        private void EditCustomer(NewCustomerRequest request)
        {
            var customer = _customerRepository.FirstOrDefault(x => x.CustomerId == request.CustomerId);

            if (customer != null)
            {
                customer.FullName = request.Name;
                customer.Address = request.Address;
                customer.MobileNo = request.ContactNo;
                customer.Email = request.Email;
                customer.Gender = request.Gender;
                customer.LoyaltyCardNo = request.LoyaltyCardNo;
            }

            _customerRepository.SaveChanges();
        }

        public void RemoveCustomer(string customerId)
        {
            var customer = _customerRepository
                .FirstOrDefault(c => c.CustomerId == customerId);

            if(customer != null)
            {
                _customerRepository.Remove(customer);
                _customerRepository.SaveChanges();
            }       
        }
    }
}
