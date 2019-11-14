using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.EF.Repositories
{
    public class CustomerScheduleRepository : RepositoryBase<CustomerSchedule>, ICustomerScheduleRepository
    {
        public CustomerScheduleRepository(IContextFactory contextFactory)
            :base(contextFactory)
        {

        }
    }
}
