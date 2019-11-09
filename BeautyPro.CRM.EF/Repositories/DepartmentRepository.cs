using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.EF.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IContextFactory contextFactory)
            :base(contextFactory)
        {

        }
    }
}
