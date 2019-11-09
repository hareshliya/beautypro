using BeautyPro.CRM.EF.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.EF.Interfaces
{
    public class ContextFactory : IDisposable, IContextFactory
    {
        private BeautyProContext _dbContext;

        public BeautyProContext DbContext
        {
            get
            {
                if(_dbContext == null)
                {
                    _dbContext = new BeautyProContext();
                }

                return _dbContext;
            }
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
