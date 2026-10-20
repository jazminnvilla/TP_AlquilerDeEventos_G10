
using Microsoft.EntityFrameworkCore;
using AlquilerDeEventos.Datos.Modelo;

namespace AlquilerDeEventos.Datos.Contexto
{
    public class AlquileresContext : DbContext
    {
        public AlquileresContext(
            DbContextOptions<AlquileresContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<DetalleAlquiler> DetallesAlquiler { get; set; }
    }
}