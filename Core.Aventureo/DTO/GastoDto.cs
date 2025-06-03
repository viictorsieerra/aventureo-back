using System;

namespace Core.Aventureo.DTO
{
    public record CreateGastoDTO
    {
        public int idViaje { get; set; }
        public int idCategoria { get; set; }

        public string? nombre { get; set; }
        public decimal cantidad { get; set; } = 0;
    }
    public record UpdateGastoDTO
    {
        public int idGasto { get; set; }
        public int idCategoria { get; set; }
        public string? nombre { get; set; }
        public decimal cantidad { get; set; } = 0;
    }
    public record GastoDTO
    {
        public int idGasto { get; set; }
        public int idViaje { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; } = 0;
    }

    public record GastoCategoriaDTO
    {
        public decimal total { get; set; }
        public int idCategoria { get; set; }
        public string categoria { get; set; }
        public int idViaje { get; set; }
    }
}
