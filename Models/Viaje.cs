using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AventureoBack.Models;

[Table("Viaje")]
public class Viaje
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idViaje { get; set; }

    [ForeignKey("usuario")]
    public int idUsuario { get; set; }

    public string? nombre { get; set; }
    public decimal cantidadTotal { get; set; }
    public int personas { get; set; }

    public virtual Usuario? usuario { get; set; }
    public virtual List<Gasto>? gastos { get; set; }
}
