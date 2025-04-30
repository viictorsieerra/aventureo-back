namespace AventureoBack.Models;

public class Usuario
{
    public int idUsuario { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public DateTime FecNacimiento { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }

    
    public ICollection<Plan> Planes { get; set; }
    public ICollection<Viaje> Viajes { get; set; }
}
