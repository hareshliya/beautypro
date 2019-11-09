using BeautyPro.CRM.Api.Constants;
using BeautyPro.CRM.Api.Helpers;
using BeautyPro.CRM.Api.Services.Interfaces;
using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using BeautyPro.CRM.EF.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeautyPro.CRM.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        // private List<User> _users = t

        //private List<User> _users = new List<User>
        //{
        //    new User { UserId = 1, FullName = "Admin", UserName = "admin", Password = "admin", UserType = Role.Admin },
         
        //};

        private readonly AppSettings _appSettings;

        public UserService(
            IOptions<AppSettings> appSettings,
            IUserRepository userRepository
            )
        {
            _appSettings = appSettings.Value;
            this._userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {

            var user = _userRepository.FirstOrDefault(x => x.UserName == username && x.Password == password);
            // var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // return user.WithoutPassword();
            return user;
        }

        /*public IEnumerable<User> GetAll()
        {
            return _users.WithoutPasswords();
        }

        public User GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            return user.WithoutPassword();
        }*/
    }
}
