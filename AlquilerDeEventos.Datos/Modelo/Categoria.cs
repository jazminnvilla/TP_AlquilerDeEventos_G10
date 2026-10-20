
using System.Xml.Linq;

namespace AlquilerDeEventos.Datos.Modelo
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";

        public List<Elemento> Elementos { get; set; } = new();
    }
}
