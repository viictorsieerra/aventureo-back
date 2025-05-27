using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record CreatePlanDTO
    {
        public int IdUsuario { get; set; } = 0;
        public string Lugar {  get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; } = 0;
        public decimal PrecioEstimado { get; set; }
        public int Valoracion { get; set; } = 1;
        public string Comentario { get; set; } = "";
    }
    public record UpdatePlanDTO
    {
        public int IdPlan { get; set; } = 0;
        public string Lugar { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; } = 0;
        public decimal PrecioEstimado { get; set; }
        public int Valoracion { get; set; } = 1;
    }
}
