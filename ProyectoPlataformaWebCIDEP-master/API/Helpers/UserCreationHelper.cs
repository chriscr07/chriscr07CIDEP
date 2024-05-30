using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace API.Helpers
{
    public class UserCreationHelper
    {
        public static string HashPassword(string contrasenna)
        {
            string salt = GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(contrasenna, salt);

            return hash;
        }

        public static string GenerateSalt()
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            return salt;
        }
    }
}