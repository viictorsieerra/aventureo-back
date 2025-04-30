namespace AventureoBack.Models
{
    public class Plan
    {
        public int idPlan { get; set; }
        public int idUsuario { get; set; }
        public string Lugar { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public decimal PrecioEstimado { get; set; }
        public int Valoracion { get; set; }

        
        public Usuario Usuario { get; set; }
        public ICollection<PartePlan> PartesPlan { get; set; }
    }
}
