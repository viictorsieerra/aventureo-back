using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AventureoBack.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idCategoria { get; set; }

    public string? nombre { get; set; }
    public string? descripcion { get; set; }

    public virtual ICollection<Gasto>? gastos { get; set; }
}
