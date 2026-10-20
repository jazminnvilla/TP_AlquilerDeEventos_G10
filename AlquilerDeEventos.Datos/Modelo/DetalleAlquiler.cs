
namespace AlquilerDeEventos.Datos.Modelo
{
    public class DetalleAlquiler
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int ElementoId { get; set; }

        public Elemento Elemento { get; set; } = null!;

        public int AlquilerId { get; set; }

        public Alquiler Alquiler { get; set; } = null!;
    }
}
