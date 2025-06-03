using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Interfaces.Utils;
using Microsoft.Extensions.Configuration;

namespace Application.Aventureo.Utils
{
    public class SecurityUtils : ISecurityUtils
    {
        private readonly IConfiguration _configuration;
        public SecurityUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> HashPassword(string password)
        {
            string hashKey = _configuration["JWT:HashKey"];
            if (string.IsNullOrEmpty(hashKey))
            {
                throw new InvalidOperationException("La clave de hash no está configurada.");
            }

            byte[] claveBytes = Encoding.UTF8.GetBytes(hashKey);
            using (HMACSHA256 hmac = new HMACSHA256(claveBytes))
            {
                byte[] textoBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = await Task.Run(() => hmac.ComputeHash(textoBytes)).ConfigureAwait(false);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
