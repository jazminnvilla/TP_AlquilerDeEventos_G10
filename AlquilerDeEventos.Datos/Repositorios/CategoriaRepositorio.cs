
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

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
            categoria.Nombre = categoria.Nombre.Trim();

            bool existe = _context.Categorias.Any(c =>
                c.Nombre.ToLower() == categoria.Nombre.ToLower());

            if (existe)
            {
                throw new InvalidOperationException(
                    "Ya existe una categoría con ese nombre.");
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        // CONSULTA
        public List<Categoria> ObtenerTodos()
        {
            return _context.Categorias
                .AsNoTracking()
                .ToList();
        }

        // MODIFICACION
        public void Modificar(Categoria categoria)
        {
            categoria.Nombre = categoria.Nombre.Trim();

            bool existe = _context.Categorias.Any(c =>
                c.Nombre.ToLower() == categoria.Nombre.ToLower()
                && c.Id != categoria.Id);

            if (existe)
            {
                throw new InvalidOperationException(
                    "Ya existe otra categoría con ese nombre.");
            }

            var categoriaExistente = _context.Categorias
                .FirstOrDefault(c => c.Id == categoria.Id);

            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoria.Nombre;
                _context.SaveChanges();
            }
        }

        // BAJA
        public void Eliminar(int id)
        {
            var categoria = _context.Categorias
                .FirstOrDefault(c => c.Id == id);

            if (categoria == null)
            {
                return;
            }

            bool tieneElementos = _context.Elementos
                .Any(e => e.CategoriaId == id);

            if (tieneElementos)
            {
                throw new InvalidOperationException(
                    "No se puede eliminar la categoría porque tiene elementos relacionados.");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}
