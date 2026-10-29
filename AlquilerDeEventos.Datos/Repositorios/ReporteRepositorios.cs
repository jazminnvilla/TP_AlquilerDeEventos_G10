
using AlquilerDeEventos.Datos.Contexto;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeEventos.Datos.Repositorios
{
    public class ReporteRepositorio
    {
        private readonly AlquileresContext _context;

        public ReporteRepositorio(AlquileresContext context)
        {
            _context = context;
        }

        // REPORTE 1: DISPONIBILIDAD POR FECHA
        public object DisponibilidadPorFecha(DateTime fecha)
        {
            var elementos = _context.Elementos
                .AsNoTracking()
                .ToList();

            var detalles = _context.DetallesAlquiler
                .Include(d => d.Alquiler)
                .AsNoTracking()
                .ToList();

            var resultado = elementos.Select(e => new
            {
                e.Id,
                e.Nombre,
                e.CantidadTotal,

                CantidadDisponible = e.CantidadTotal -
                    detalles.Where(d =>
                        d.ElementoId == e.Id &&
                        d.Alquiler.Estado != "Cancelado" &&
                        d.Alquiler.FechaInicio.Date <= fecha.Date &&

                        // Si hubo devolución, usamos la fecha real.
                        // Si sigue entregado, continúa ocupado.
                        // En otros casos, usamos la fecha final.
                        (
                            d.Alquiler.FechaDevolucionReal != null
                                ? fecha.Date <=
                                  d.Alquiler.FechaDevolucionReal.Value.Date

                                : d.Alquiler.Estado == "Entregado"
                                    || fecha.Date <=
                                       d.Alquiler.FechaFin.Date
                        )
                    ).Sum(d => d.Cantidad)

            }).ToList();

            return resultado;
        }

        // REPORTE 2: RESERVAS PENDIENTES
        public object ReservasPendientes()
        {
            var resultado = _context.Alquileres
                .AsNoTracking()
                .Where(a => a.Estado == "Pendiente")
                .OrderBy(a => a.FechaReserva)
                .Select(a => new
                {
                    a.Id,
                    a.ClienteId,
                    a.FechaReserva,
                    a.FechaInicio,
                    a.FechaFin,
                    a.Total
                })
                .ToList();

            return resultado;
        }

        // REPORTE 3: ALQUILERES ENTRE FECHAS
        public object AlquileresEntreFechas(
            DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException(
                    "La fecha inicial no puede ser posterior a la final.");
            }

            var resultado = _context.Alquileres
                .AsNoTracking()
                .Where(a =>
                    a.FechaInicio >= desde.Date &&
                    a.FechaInicio < hasta.Date.AddDays(1))
                .OrderBy(a => a.FechaInicio)
                .Select(a => new
                {
                    a.Id,
                    a.ClienteId,
                    a.FechaInicio,
                    a.FechaFin,
                    a.Estado,
                    a.Total
                })
                .ToList();

            return resultado;
        }

        // REPORTE 4: ELEMENTOS MAS ALQUILADOS
        public object ElementosMasAlquilados()
        {
            var detalles = _context.DetallesAlquiler
                .Include(d => d.Elemento)
                .Include(d => d.Alquiler)
                .AsNoTracking()
                .ToList();

            var resultado = detalles
                .Where(d => d.Alquiler.Estado != "Cancelado")
                .GroupBy(d => new
                {
                    d.ElementoId,
                    d.Elemento.Nombre
                })
                .Select(g => new
                {
                    Id = g.Key.ElementoId,
                    Elemento = g.Key.Nombre,
                    UnidadesAlquiladas = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(x => x.UnidadesAlquiladas)
                .ToList();

            return resultado;
        }

        // REPORTE 5: ALQUILERES ATRASADOS
        public object PendientesDeDevolucion()
        {
            var resultado = _context.Alquileres
                .AsNoTracking()
                .Where(a =>
                    a.Estado == "Entregado" &&
                    a.FechaFin < DateTime.Today &&
                    a.FechaDevolucionReal == null)
                .OrderBy(a => a.FechaFin)
                .Select(a => new
                {
                    a.Id,
                    a.ClienteId,
                    a.FechaInicio,
                    a.FechaFin,
                    a.Estado,
                    a.Total
                })
                .ToList();

            return resultado;
        }
    }
}
