
namespace AlquilerDeEventos.Datos.Modelo
{
    public class Elemento
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";

        public string Descripcion { get; set; } = "";

        public decimal PrecioPorDia { get; set; }

        public int CantidadTotal { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; } = null!;

        public List<DetalleAlquiler> DetallesAlquiler { get; set; } = new();
    }
}
