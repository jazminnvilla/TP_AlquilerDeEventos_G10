
namespace AlquilerDeEventos.Datos.Modelo
{
    public class Empleado : Persona
    {
        public string Usuario { get; set; } = "";
        public string ContrasenaHash { get; set; } = "";
    }
}
