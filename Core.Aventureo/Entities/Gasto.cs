using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Aventureo.Entities
{

    [Table("Gasto")]
    public class Gasto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGasto { get; set; }

        [ForeignKey("viaje")]
        public int idViaje { get; set; }

        [ForeignKey("categoria")]
        public int idCategoria { get; set; }

        public string? nombre { get; set; }
        public decimal cantidad { get; set; }

        public virtual Viaje? viaje { get; set; }
        public virtual Categoria? categoria { get; set; }
    }
}
