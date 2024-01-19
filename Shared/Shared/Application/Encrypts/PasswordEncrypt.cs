using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace BusinessApp.Shared.Application.Encrypts
{
    public class PasswordEncrypt
    {
        public static string Encrypt(string password)
        {
                using var hmac = MD5.Create();  
           
                var bytePassword = Encoding.UTF8.GetBytes(password);
                var hashBytes = hmac.ComputeHash(bytePassword);
                return Convert.ToHexString(hashBytes);
            

        }
    }
}
