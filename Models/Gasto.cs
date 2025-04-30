namespace AventureoBack.Models
{
    public class Gasto
    {
        public int idGasto { get; set; }
        public int idViaje { get; set; }
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }

      
        public Viaje Viaje { get; set; }
        public Categoria Categoria { get; set; }
    }
}
