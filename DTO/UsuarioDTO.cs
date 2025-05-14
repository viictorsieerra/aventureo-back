namespace Aventureo_Back.DTO
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
        public bool? RolAdmin {  get; set; }
    }
    public record class RegisterUserDTO
    {
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public DateTime fecNacimiento { get; set; } = DateTime.Now;
        public string? email { get; set; }
        public string? contrasena { get; set; }
    }
}
