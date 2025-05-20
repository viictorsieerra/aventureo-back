using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Aventureo.Dto;
using Core.Aventureo.Interfaces.Repository.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Aventureo.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration? _configuration;
        private readonly IUserRepository? _repository;

        public JwtAuthService(IConfiguration? configuration, IUserRepository? repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<TokenDto> GenerateTokenAsync(UserOutDTO user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RolAdmin == true ? "User" : "admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new TokenDto { Value = tokenString };
        }

        public async Task<TokenDto> Login(LoginDTO login)
        {
            login.Contrasena = await HashPassword(login.Contrasena);
            UserOutDTO user = await _repository.GetUserFromCredentials(login);

            if (user == null)
                throw new KeyNotFoundException("Usuario o contraseña incorrectos");

            return await GenerateTokenAsync(user);
        }


        public async Task<TokenDto> RegisterUser(RegisterUserDTO registerUser)
        {
            registerUser.contrasena = await HashPassword(registerUser.contrasena);
            UserOutDTO user = await _repository.RegisterUserFromCredentials(registerUser);
            return await GenerateTokenAsync(user);
        }

        public async Task<string> HashPassword(string password)
        {

            byte[] claveBytes = Encoding.UTF8.GetBytes(_configuration["JWT:HashKey"]);

            using (HMACSHA256 hmac = new HMACSHA256(claveBytes))
            {
                byte[] textoBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = hmac.ComputeHash(textoBytes);

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
