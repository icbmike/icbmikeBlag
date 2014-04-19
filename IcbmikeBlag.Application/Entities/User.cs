using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IcbmikeBlag.Application.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public string Password
        {
            set { HashedPassword = HashAndSalt(value); }
        }

        public bool Validate(string password)
        {
            return HashAndSalt(password) == HashedPassword;
        }

        private string HashAndSalt(string password)
        {
            //Ensure that Salt is set
            Salt = Salt ?? GenerateSalt();

            var encoding = new UTF8Encoding();

            var passwordBytes = encoding.GetBytes(password);
            var saltBytes = encoding.GetBytes(Salt);

            //Construct the byte array that will be hashed
            var valueToHash = new byte[passwordBytes.Count() + saltBytes.Count()];


            passwordBytes.CopyTo(valueToHash, 0);
            saltBytes.CopyTo(valueToHash, passwordBytes.Count());

            var sha512Managed = new SHA512Managed();
            var computedHash = sha512Managed.ComputeHash(valueToHash);

            var hashString = computedHash.Aggregate("", (current, hexDigit) => current + hexDigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat));

            return hashString + Salt;

        }

        private static string GenerateSalt()
        {
            var random = new Random((int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);

            var saltBytes = new byte[128];
            random.NextBytes(saltBytes);

            var encoding = new UTF8Encoding();

            return encoding.GetString(saltBytes);
        }
    }
}
