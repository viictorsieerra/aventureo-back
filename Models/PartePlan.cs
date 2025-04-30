namespace AventureoBack.Models
{
    public class PartePlan
    {
        public int idPartePlan { get; set; }
        public int idPlan { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public string Comentario { get; set; }

        
        public Plan Plan { get; set; }
    }
}
