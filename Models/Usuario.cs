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
    public string? email { get; set; }
    public string? contraseña { get; set; }

    public virtual List<Plan>? planes { get; set; }
    public virtual List<Viaje>? viajes { get; set; }
}
