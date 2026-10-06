# TP\_AlquilerDeEventos\_G10

"Sistema de gestión de alquileres de elementos para eventos"



&#x20;##Descripción del sistema



Sistema de escritorio para la gestión de un negocio de alquiler de elementos para eventos, como cumpleaños, casamientos o reuniones. El sistema es utilizado por el personal del negocio, que registra a los clientes, administra el catálogo de elementos disponibles (mesas, sillas, vajilla, manteles, iluminación, etc.) y carga los alquileres. Antes de confirmar un alquiler, el sistema verifica que haya unidades disponibles de cada elemento para las fechas solicitadas, teniendo en cuenta los alquileres ya registrados para esos días. De esta forma se evita comprometer más unidades de las que el negocio realmente tiene.





\### Entidades principales



\*\*Cliente\*\*: persona que alquila elementos para un evento. Se registran sus datos personales y de contacto.

\*\*Categoria\*\*: agrupa los elementos según su tipo, por ejemplo mesas, sillas o vajilla.

\*\*Elemento\*\*: artículo que el negocio ofrece en alquiler. Tiene un precio por día y una cantidad total de unidades.

\*\*Alquiler\*\*: reserva que realiza un cliente para un rango de fechas. Tiene un estado (Reservado, Entregado, Devuelto o Cancelado) y un importe total.

\- \*\*DetalleAlquiler\*\*: cada elemento incluido en un alquiler, con la cantidad de unidades y el precio al momento de alquilar. Permite que un mismo alquiler incluya varios elementos distintos.

