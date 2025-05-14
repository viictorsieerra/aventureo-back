namespace AventureoBack.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idUsuario { get; set; }
    public string? nombre { get; set; }
    public string? apellidos { get; set; }
    public DateTime fecNacimiento { get; set; } = DateTime.Now;
    [Required]
    public string email { get; set; }
    public string? contrasena { get; set; }
    public bool? RolAdmin { get; set; } = false;

    public virtual List<Plan>? planes { get; set; }
    public virtual List<Viaje>? viajes { get; set; }

    public Usuario(){}
    public Usuario (int _idUsuario, string _nombre, string _apellidos, DateTime _fecNacimiento, string _email, string _contrasena)
    {
        idUsuario = _idUsuario;
        nombre = _nombre;
        apellidos = _apellidos;
        fecNacimiento = _fecNacimiento;
        email = _email;
        contrasena = _contrasena;
    }
}
