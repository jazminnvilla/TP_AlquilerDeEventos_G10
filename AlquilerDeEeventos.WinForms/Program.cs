
using AlquilerDeEventos.Datos.Contexto;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeEeventos.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var opciones = new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlite(
                    @"Server=(localdb)\MSSQLLocalDB;Database=AlquilerDeEventosDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var contexto = new AlquileresContext(opciones);

            Application.Run(new Form1());
        }
    }
}
