namespace AventureoBack.Models
{
    public class Viaje
    {
        public int idViaje { get; set; }
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public decimal CantidadTotal { get; set; }
        public int Personas { get; set; }

       
        public Usuario Usuario { get; set; }
        public ICollection<Gasto> Gastos { get; set; }
    }
}
