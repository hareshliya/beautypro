using BeautyPro.CRM.Contract.DTO;
using BeautyPro.CRM.Contract.DTO.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDTO> SearchCustomer(CustomerSearchRequest request);
        void AddEditCustomer(NewCustomerRequest request, int userId, int branchId);
        void RemoveCustomer(string customerId, int userId);
        CustomerDTO GetCustomer(string customerId);
        List<CustomerDTO> SearchCustomersForConfirmedSchedulesForToday(CustomerSearchRequest request);
    }
}
