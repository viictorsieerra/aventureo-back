using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record class CreatePartePlanDTO
    {
        public int idPlan { get; set; }
        public string? nombre { get; set; }
        public string? ubicacion { get; set; }
        public decimal precio { get; set; }
        public string? comentario { get; set; }
    }
    public record class UpdatePartePlanDTO
    {
        public int idPartePlan { get; set; }
        public string? nombre { get; set; }
        public string? ubicacion { get; set; }
        public decimal precio { get; set; }
        public string? comentario { get; set; }
    }
}
