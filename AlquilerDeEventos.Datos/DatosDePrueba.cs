
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeEventos.Datos
{
    public static class DatosDePrueba
    {
        public static void Cargar(AlquileresContext context)
        {
            // Evitamos cargar dos veces los datos.
            if (context.Clientes.Any(c =>
                c.Dni == "99999999"))
            {
                return;
            }

            // CATEGORIA
            Categoria categoria = context.Categorias
                .FirstOrDefault(c => c.Nombre == "Mobiliario")
                ?? new Categoria { Nombre = "Mobiliario" };

            if (categoria.Id == 0)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }

            // ELEMENTOS
            Elemento sillas = new Elemento
            {
                Nombre = "Sillas de prueba",
                Descripcion = "Sillas para eventos",
                PrecioPorDia = 1000,
                CantidadTotal = 30,
                CategoriaId = categoria.Id
            };

            Elemento mesas = new Elemento
            {
                Nombre = "Mesas de prueba",
                Descripcion = "Mesas para eventos",
                PrecioPorDia = 5000,
                CantidadTotal = 10,
                CategoriaId = categoria.Id
            };

            context.Elementos.AddRange(sillas, mesas);

            // CLIENTE
            Cliente cliente = new Cliente
            {
                Nombre = "Cliente",
                Apellido = "Prueba",
                Dni = "99999999",
                Telefono = "0000000000",
                Email = "prueba@ejemplo.com",
                Direccion = "Dirección ficticia"
            };

            context.Clientes.Add(cliente);
            context.SaveChanges();

            // ALQUILER PENDIENTE
            Alquiler pendiente = new Alquiler
            {
                ClienteId = cliente.Id,
                FechaReserva = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(5),
                FechaFin = DateTime.Today.AddDays(7),
                Estado = "Pendiente",
                Total = 8000
            };

            // ALQUILER ENTREGADO Y ATRASADO
            Alquiler atrasado = new Alquiler
            {
                ClienteId = cliente.Id,
                FechaReserva = DateTime.Today.AddDays(-12),
                FechaInicio = DateTime.Today.AddDays(-10),
                FechaFin = DateTime.Today.AddDays(-3),
                Estado = "Entregado",
                Total = 5000
            };

            // ALQUILER DEVUELTO
            Alquiler devuelto = new Alquiler
            {
                ClienteId = cliente.Id,
                FechaReserva = DateTime.Today.AddDays(-20),
                FechaInicio = DateTime.Today.AddDays(-15),
                FechaFin = DateTime.Today.AddDays(-13),
                FechaDevolucionReal = DateTime.Today.AddDays(-13),
                Estado = "Devuelto",
                Total = 10000
            };

            context.Alquileres.AddRange(
                pendiente, atrasado, devuelto);

            context.SaveChanges();

            // DETALLES DE LOS ALQUILERES
            context.DetallesAlquiler.AddRange(
                new DetalleAlquiler
                {
                    AlquilerId = pendiente.Id,
                    ElementoId = sillas.Id,
                    Cantidad = 8,
                    PrecioUnitario = 1000
                },
                new DetalleAlquiler
                {
                    AlquilerId = atrasado.Id,
                    ElementoId = sillas.Id,
                    Cantidad = 5,
                    PrecioUnitario = 1000
                },
                new DetalleAlquiler
                {
                    AlquilerId = devuelto.Id,
                    ElementoId = mesas.Id,
                    Cantidad = 2,
                    PrecioUnitario = 5000
                }
            );

            context.SaveChanges();
        }
    }
}
