namespace Core.Aventureo.DTO
{
    public record LoginDTO
    {
        public string? Email {  get; set; }
        public string? Contrasena { get; set; }
    }
    public record UserOutDTO
    {
        public int? IdUsuario { get; set; }
        public string? Email { get; set; }
        public bool? RolAdmin {  get; set; } = false;
    }
    public record RegisterUserDTO
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; } = DateTime.Now;
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
    }
    public record AddModUserDTO
    {
        public int IdUsuario { get; set; } = 0;
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; } = DateTime.Now;
        public string? Email { get; set; }
        public string? Contrasena { get; set; }
        public bool? RolAdmin { get; set; } = false;
    }
    public record UpdateUserDTO
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Contrasena { get; set; }
    }

    public record TokenDto
    {
        public string? Value { get; set; }
    }
}
