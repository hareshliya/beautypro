using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.EF.Repositories
{
    public class CustomerInvoiceHeaderRepository : RepositoryBase<CustomerInvoiceHeader>, ICustomerInvoiceHeaderRepository
    {
        public CustomerInvoiceHeaderRepository(IContextFactory contextFactory)
            :base(contextFactory)
        {

        }
    }
}
