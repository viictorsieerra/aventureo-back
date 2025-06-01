using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Aventureo.Utils;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.Repository.Entities;
using Core.Aventureo.Interfaces.Service;
using Core.Aventureo.Interfaces.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Aventureo.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration? _configuration;
        private readonly IUserRepository? _repository;
        private readonly ISecurityUtils? _utils;

        public JwtAuthService(IConfiguration? configuration, IUserRepository? repository, ISecurityUtils utils)
        {
            _configuration = configuration;
            _repository = repository;
            _utils = utils;
        }

        public async Task<TokenDto> GenerateTokenAsync(UserOutDTO user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RolAdmin == false ? "User" : "Admin")
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new TokenDto {  Value = tokenString};
        }

        public async Task<TokenDto> Login(LoginDTO login)
        {
            login.Contrasena = await _utils.HashPassword(login.Contrasena);
            UserOutDTO user = await _repository.GetUserFromCredentials(login);

            if (user == null)
                throw new KeyNotFoundException("Usuario o contraseña incorrectos");

            return await GenerateTokenAsync(user);
        }


        public async Task<TokenDto> RegisterUser(RegisterUserDTO registerUser)
        {
            registerUser.Contrasena = await _utils.HashPassword(registerUser.Contrasena);
            UserOutDTO user = await _repository.RegisterUserFromCredentials(registerUser);
            return await GenerateTokenAsync(user);
        }


    }
}
