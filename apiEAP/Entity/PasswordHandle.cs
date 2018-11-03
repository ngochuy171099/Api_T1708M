using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace apiEAP.Entity
{
    public class PasswordHandle
    {
        private static PasswordHandle _instance;
        public static PasswordHandle GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PasswordHandle();
            }

            return _instance;
        }

        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string EncryPassword(string originalPassword, string salt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(originalPassword + salt) )
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
