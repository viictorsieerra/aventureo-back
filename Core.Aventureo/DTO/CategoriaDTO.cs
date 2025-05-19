namespace Core.Aventureo.Dto
{
    public record class CreateCategoriaDTO
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
    public record class UpdateCategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
