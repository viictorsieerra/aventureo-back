namespace Core.Aventureo.DTO
{
    public record class LoginDTO
    {
        public string? Email {  get; set; }
        public string? Contrasena { get; set; }
    }
    public record class UserOutDTO
    {
        public int? IdUsuario { get; set; }
        public string? Email { get; set; }
        public bool? RolAdmin {  get; set; } = false;
    }
    public record class RegisterUserDTO
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; } = DateTime.Now;
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
    }
    public record class AddModUserDTO
    {
        public int IdUsuario { get; set; } = 0;
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; } = DateTime.Now;
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public bool? RolAdmin { get; set; } = false;
    }
    public record class UpdateUserDTO
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Contrasena { get; set; }
    }

    public record class TokenDto
    {
        public string? Value { get; set; }
    }
}
