
namespace AlquilerDeEventos.Datos.Modelo
{
    public class Alquiler
    {
        public int Id { get; set; }

        public DateTime FechaReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public DateTime? FechaConfirmacion { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        public string Estado { get; set; } = "Pendiente";
        public string MedioPago { get; set; } = "";

        public decimal Total { get; set; }
        public decimal Recargo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int? EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        public List<DetalleAlquiler> DetallesAlquiler { get; set; } = new();

        public void RegistrarDevolucion(DateTime fecha, decimal recargo)
        {
            if (Estado != "Entregado")
                throw new InvalidOperationException(
                    "El alquiler debe estar entregado para registrar su devolución.");

            if (fecha < FechaInicio)
                throw new ArgumentException(
                    "La fecha de devolución no puede ser anterior al inicio.");

            if (recargo < 0)
                throw new ArgumentException(
                    "El recargo no puede ser negativo.");

            if (fecha <= FechaFin && recargo > 0)
                throw new ArgumentException(
                    "No corresponde un recargo si la devolución fue a tiempo.");

            FechaDevolucionReal = fecha;
            Recargo = recargo;
            Estado = "Devuelto";
        }
    }
}
