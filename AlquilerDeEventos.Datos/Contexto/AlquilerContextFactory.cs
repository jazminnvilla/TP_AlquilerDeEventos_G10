
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlquilerDeEventos.Datos.Contexto
{
    public class AlquileresContextFactory
        : IDesignTimeDbContextFactory<AlquileresContext>
    {
        public AlquileresContext CreateDbContext(string[] args)
        {
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "AlquilerDeEventos.db");

            var opciones = new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlite($"Data Source={ruta}")
                .Options;

            return new AlquileresContext(opciones);
        }
    }
}
