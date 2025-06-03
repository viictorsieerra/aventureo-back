namespace Core.Aventureo.DTO
{
    public record CreateCategoriaDTO
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
    public record UpdateCategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
