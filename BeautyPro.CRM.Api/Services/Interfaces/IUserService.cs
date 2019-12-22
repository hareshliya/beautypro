using BeautyPro.CRM.EF.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyPro.CRM.Api.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        // IEnumerable<User> GetAll();
        // User GetById(int id);
        User Create(User user, string password);
    }
}
