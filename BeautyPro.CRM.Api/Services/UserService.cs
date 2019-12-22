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
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeautyPro.CRM.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private const string mkey = "4EB9ABFD98BA2E25F5F1B0403AE67F37188069EDD2B41460BCD9182B619CC4D9";

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

            var encryptedPassword = Encrypt(password);
            var user = _userRepository.FirstOrDefault(x => x.UserName == username && x.Password == encryptedPassword);

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
                    new Claim(ClaimTypes.Role, user.UserType),
                    new Claim(ClaimConstants.BARNCH_ID, user.BranchId.ToString()),
                    new Claim(ClaimConstants.DEPARTMENT_ID, user.DepartmentId.HasValue ? user.DepartmentId.Value.ToString() : string.Empty)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // return user.WithoutPassword();
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required");
            }

            if(_userRepository.All.Any(x => x.UserName == user.UserName))
            {
                throw new Exception("Username \"" + user.UserName + "\" is already taken");
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                var encryptedPassword = Encrypt(password);
                user.Password = encryptedPassword;
            }

            _userRepository.Add(user);
            _userRepository.SaveChanges();

            return user;
        }

        private static string Encrypt(string dataToEncrypt)
        {
            byte[] key = GetHashKey(mkey);
            // Initialize
            AesManaged encryptor = new AesManaged();
            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }   

        public static byte[] GetHashKey(string hashKey)
        {
            // Initialize
            UTF8Encoding encoder = new UTF8Encoding();
            // Get the salt
            string salt = "2790164838";
            byte[] saltBytes = encoder.GetBytes(salt);
            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            // Return the key
            return rfc.GetBytes(16);
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
