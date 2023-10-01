using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Common.Helpers
{
    public class PasswordHandler
    {
        public static string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            // Hash the password using PBKDF2 algorithm
            byte[] hashedPassword = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );

            return Convert.ToBase64String(hashedPassword);
        }

        public static bool VerifyPassword(string inputPassword, string storedHashedPassword, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            byte[] decodedHashedPassword = Convert.FromBase64String(storedHashedPassword);

            // Hash the provided password using the same parameters
            byte[] hashedPassword = KeyDerivation.Pbkdf2(
                password: inputPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );

            bool passwordsMatch = hashedPassword.SequenceEqual(decodedHashedPassword);

            return passwordsMatch;
        }
    }
}
