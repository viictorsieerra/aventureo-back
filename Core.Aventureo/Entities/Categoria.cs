using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Aventureo.Entities
{

    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual List<Gasto>? Gastos { get; set; }
    }
}
