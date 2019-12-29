using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.Mapper;
using BeautyProCRM.Business.Constants;
using BeautyProCRM.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var customers = _customerRepository.All
                .OrderByDescending(x => x.EnteredDate)
                .Where(x => !x.IsDeleted && x.DeletedBy == null);

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                customers = customers.Where(c => c.FullName.Contains(request.SearchText));
            }

            return DomainDTOMapper.ToCustomerDTOs(customers.ToList());
        }

        public List<CustomerDTO> SearchCustomersForConfirmedSchedulesForToday(CustomerSearchRequest request)
        {
            var customers = 
                _customerRepository
                .All          
                .Include(x => x.CustomerSchedules)
                .Where(x => !x.IsDeleted && x.DeletedBy == null 
                && x.CustomerSchedules.Any(c => c.Status == AppoinmentConstant.CONFIRMED && c.BookedDate == DateTime.Now.Date && c.DepartmentId == request.DepartmentId));

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                customers = customers.Where(c => c.FullName.Contains(request.SearchText));
            }

            return DomainDTOMapper.ToCustomerDTOs(customers.ToList());
        }

        public void AddEditCustomer(NewCustomerRequest request, int userId, int branchId)
        {
            if (!string.IsNullOrWhiteSpace(request.CustomerId))
            {
                EditCustomer(request, userId, branchId);
            }
            else
            {
                AddCustomer(request, userId, branchId);
            }
        }

        private void AddCustomer(NewCustomerRequest request, int userId, int branchId)
        {
            var customerNo = String.Format("C{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            _customerRepository.Add(DomainDTOMapper.ToCustomerDomain(new CustomerDTO()
            {
                CustomerId = customerNo,
                FullName = request.Name,
                Address = request.Address,
                Gender = request.Gender,
                LoyaltyCardNo = request.LoyaltyCardNo,
                Email = request.Email,
                MobileNo = request.ContactNo,
                BranchId = branchId,
                EnteredDate = DateTime.Now,
                EnteredBy = userId
            }));

            _customerRepository.SaveChanges();
        }

        private void EditCustomer(NewCustomerRequest request, int userId, int branchId)
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
                customer.BranchId = branchId;
                customer.ModifiedBy = userId;
                customer.ModifiedDate = DateTime.Now;
            }

            _customerRepository.SaveChanges();
        }

        public void RemoveCustomer(string customerId, int userId)
        {
            var customer = _customerRepository
                .FirstOrDefault(c => c.CustomerId == customerId);

            if(customer != null)
            {
                customer.DeletedBy = userId;
                customer.DeletedDate = DateTime.Now;
                
                _customerRepository.SaveChanges();
            }       
        }
    }
}
