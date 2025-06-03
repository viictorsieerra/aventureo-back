using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Aventureo.Entities
{

    [Table("Plan")]
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPlan { get; set; }

        [ForeignKey("usuario")]
        public int idUsuario { get; set; }

        public string? lugar { get; set; }
        public string? nombre { get; set; }
        public int duracion { get; set; }
        public decimal precioEstimado { get; set; }
        public int valoracion { get; set; }

        public virtual Usuario? usuario { get; set; }
        public virtual List<PartePlan>? partesPlan { get; set; }
    }
}