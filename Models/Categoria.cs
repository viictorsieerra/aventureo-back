namespace AventureoBack.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

       
        public ICollection<Gasto> Gastos { get; set; }
    }
}
