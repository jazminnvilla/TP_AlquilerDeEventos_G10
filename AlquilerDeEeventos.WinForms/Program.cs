
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlquilerDeEeventos.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Configuración de inyección de dependencias.
            var servicios = new ServiceCollection();

            // Ruta de la base de datos SQLite.
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "AlquilerDeEventos.db");

            // Registro del contexto.
            servicios.AddDbContext<AlquileresContext>(opciones =>
                opciones.UseSqlite($"Data Source={ruta}"));

            // Registro de repositorios.
            servicios.AddScoped<CategoriaRepositorio>();
            servicios.AddScoped<ReporteRepositorio>();

            // Registro de formularios.
            servicios.AddScoped<Form1>();
            servicios.AddScoped<FormReportes>();

            using var proveedor = servicios.BuildServiceProvider();
            using var scope = proveedor.CreateScope();

            // Crear o actualizar las tablas mediante migraciones.
            var contexto = scope.ServiceProvider
                .GetRequiredService<AlquileresContext>();

            contexto.Database.Migrate();

            // Iniciar el formulario principal.
            Application.Run(
                scope.ServiceProvider.GetRequiredService<Form1>());
        }
    }
}