using BeautyPro.CRM.EF.Interfaces;
using BeautyProCRM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyProCRM.Business
{
    public class CustomerScheduleService : ICustomerScheduleService
    {
        private readonly ICustomerScheduleRepository _customerScheduleRepository;

        public CustomerScheduleService(ICustomerScheduleRepository customerScheduleRepository)
        {
            _customerScheduleRepository = customerScheduleRepository;
        }
    }
}
