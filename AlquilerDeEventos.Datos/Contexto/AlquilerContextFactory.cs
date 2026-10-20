
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlquilerDeEventos.Datos.Contexto
{
    public class AlquileresContextFactory
        : IDesignTimeDbContextFactory<AlquileresContext>
    {
        public AlquileresContext CreateDbContext(string[] args)
        {
            var opciones =
                new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlServer(
                    @"Server=(localdb)\MSSQLLocalDB;Database=AlquilerDeEventosDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            return new AlquileresContext(opciones);
        }
    }
}
