using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AventureoBack.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }

    public virtual ICollection<Gasto>? Gastos { get; set; }
}
