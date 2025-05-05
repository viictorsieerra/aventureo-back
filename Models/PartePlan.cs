using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AventureoBack.Models;

[Table("PartePlan")]
public class PartePlan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idPartePlan { get; set; }

    [ForeignKey("plan")]
    public int idPlan { get; set; }

    public string? nombre { get; set; }
    public string? ubicacion { get; set; }
    public decimal precio { get; set; }
    public string? comentario { get; set; }

    public virtual Plan? plan { get; set; }
}
