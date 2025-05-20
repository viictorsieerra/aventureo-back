using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record class CreateViajeDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public decimal CantidadTotal { get; set; } = 0;
        public int Personas { get; set; } = 1;
    }

    public record class UpdateViajeDTO
    {
        public int IdViaje { get; set; }
        public string Nombre { get; set; }
        public decimal CantidadTotal { get; set; } = 0;
        public int Personas { get; set; } = 1;
    }
}
