using BeautyPro.CRM.EF.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyPro.CRM.Api.Models
{
    public class RegisterModel
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
