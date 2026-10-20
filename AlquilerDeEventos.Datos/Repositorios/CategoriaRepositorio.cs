
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Modelo;

namespace AlquilerDeEventos.Datos.Repositorios
{
    public class CategoriaRepositorio
    {
        private readonly AlquileresContext _context;

        public CategoriaRepositorio(AlquileresContext context)
        {
            _context = context;
        }

        // ALTA
        public void Agregar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        // CONSULTA
        public List<Categoria> ObtenerTodos()
        {
            return _context.Categorias.ToList();
        }

        // MODIFICACIÓN
        public void Modificar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        // BAJA
        public void Eliminar(int id)
        {
            var categoria = _context.Categorias
                .FirstOrDefault(c => c.Id == id);

            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}
