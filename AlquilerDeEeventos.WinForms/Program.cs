
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

            //Configuracion la inyección de dependencias
            var servicios = new ServiceCollection();

            // Configuramos SQLite.
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "AlquilerDeEventos.db");

            servicios.AddDbContext<AlquileresContext>(opciones =>
                opciones.UseSqlite($"Data Source={ruta}"));

            // Registrar los repos
            servicios.AddScoped<CategoriaRepositorio>();
            servicios.AddScoped<ReporteRepositorio>();

            // Registrar los formularios
            servicios.AddScoped<Form1>();
            servicios.AddScoped<FormReportes>();

            // Construir el proveedor de servicios
            using var proveedor = servicios.BuildServiceProvider();

            // Crear el ámbito de la ventana principal
            using var scope = proveedor.CreateScope();

            Application.Run(
                scope.ServiceProvider.GetRequiredService<Form1>());
        }
    }
}
