TP\_AlquilerDeEventos\_G10

"Sistema de gestión de alquileres de elementos para eventos"



\TP\_AlquilerDeEventos\_G10



Sistema de gestión de alquileres de elementos para eventos.



Integrantes: [Celeste Ball] - [Jazmín Villa]



\## Descripción del sistema



Sistema de escritorio para la gestión de un negocio de alquiler de elementos para eventos, como cumpleaños, casamientos o reuniones. El sistema cuenta con dos tipos de usuario. El cliente se identifica, selecciona la fecha de su evento y consulta el catálogo completo, donde cada elemento muestra la cantidad de unidades disponibles para ese día o la indicación "No disponible" si no quedan unidades. A partir de ahí, realiza su reserva eligiendo los elementos y las cantidades que necesita, y se comunica con el negocio por WhatsApp para acordar el pago. El administrador del negocio gestiona el catálogo (elementos, categorías, precios y stock), confirma las reservas una vez verificado el pago, controla el estado de los alquileres y consulta los reportes. Antes de registrar una reserva, el sistema verifica que las cantidades solicitadas no superen las unidades disponibles, evitando comprometer más elementos de los que el negocio tiene.



\### Entidades principales



\- \*\*Cliente\*\*: persona que alquila elementos para un evento. Se registran sus datos personales y de contacto.

\- \*\*Categoria\*\*: agrupa los elementos según su tipo, por ejemplo mesas, sillas o vajilla.

\- \*\*Elemento\*\*: artículo que el negocio ofrece en alquiler. Tiene un precio por día y una cantidad total de unidades.

\- \*\*Alquiler\*\*: reserva que realiza un cliente para un rango de fechas. Registra la fecha en que se hizo la reserva, su estado (Pendiente, Confirmado, Entregado, Devuelto o Cancelado), el medio de pago y el importe total.

\- \*\*DetalleAlquiler\*\*: cada elemento incluido en un alquiler, con la cantidad de unidades y el precio al momento de alquilar. Permite que un mismo alquiler incluya varios elementos distintos.



\## Objetivos



\- Permitir que los clientes consulten la disponibilidad de los elementos para la fecha de su evento y realicen sus reservas.

\- Evitar que se reserven más unidades de las que el negocio tiene disponibles en una fecha determinada.

\- Dar al negocio el control sobre la confirmación de las reservas, una vez acordado y verificado el pago.

\- Llevar un registro ordenado de clientes, elementos y alquileres.

\- Obtener información útil para la gestión del negocio mediante reportes.



\## Funcionalidades



\### Cliente



\- \*\*Identificación y registro\*\*: el cliente ingresa su DNI; si no está registrado, carga sus datos personales y de contacto.

\- \*\*Consulta del catálogo por fecha\*\*: selecciona la fecha de su evento y visualiza todos los elementos, con la cantidad de unidades disponibles o la indicación "No disponible".

\- \*\*Alta de reserva\*\*: elige los elementos y las cantidades que necesita. La reserva queda en estado Pendiente y las unidades quedan ocupadas, salvo que la reserva se cancele.

\- \*\*Contacto por WhatsApp\*\*: al registrar la reserva, se abre WhatsApp con un mensaje al negocio que incluye el detalle del alquiler, para coordinar el medio de pago.



\### Administrador



\- \*\*ABM de Elementos\*\*: alta, baja, modificación y consulta de los elementos del catálogo, con su precio por día y cantidad total.

\- \*\*ABM de Categorías\*\*: alta, baja, modificación y consulta de las categorías de elementos.

\- \*\*ABM de Clientes\*\*: consulta, modificación y baja de los clientes registrados.

\- \*\*Gestión de Alquileres\*\*: confirmar las reservas pendientes una vez verificado el pago, registrar el medio de pago, cancelar reservas y actualizar el estado (Confirmado, Entregado, Devuelto).



\### Reportes



1\. \*\*Disponibilidad por fecha\*\*: cantidad de unidades disponibles de cada elemento para una fecha determinada.

2\. \*\*Reservas pendientes de confirmación\*\*: reservas en estado Pendiente, con la fecha en que fueron realizadas.

3\. \*\*Alquileres entre fechas\*\*: listado de alquileres dentro de un período.

4\. \*\*Elementos más alquilados\*\*: ranking de elementos según la cantidad de unidades alquiladas.

5\. \*\*Alquileres pendientes de devolución\*\*: alquileres en estado Entregado cuya fecha de fin ya pasó.



\## Diagrama de clases



!\[Diagrama de clases](docs/diagrama\_clases.png)



\## Arquitectura e integración de capas



La solución se divide en dos proyectos:



\- \*\*AlquilerDeEventos.Datos (Biblioteca de clases):\*\* contiene los modelos (las clases del diagrama), el contexto de Entity Framework Core (AlquileresContext, que representa la conexión con la base de datos) y los repositorios, que se encargan de guardar y consultar los datos y de aplicar las reglas del negocio, como la verificación de disponibilidad.

\- \*\*AlquilerDeEventos.UI (Aplicación WinForms):\*\* contiene los formularios. Muestra la información, recibe los datos que ingresa el usuario y valida que estén completos y sean correctos. No accede directamente a la base de datos, sino que lo hace a través de los repositorios.



\### Ejemplo: cómo se guarda una reserva



1\. \*\*Interfaz (WinForms):\*\* el cliente selecciona las fechas, elige los elementos y sus cantidades, y presiona "Reservar". El formulario valida que los campos obligatorios estén completos, que las cantidades sean números mayores a cero y que la fecha de fin no sea anterior a la de inicio.

2\. \*\*Interfaz → Biblioteca de clases:\*\* el formulario crea un objeto Alquiler con sus DetalleAlquiler y se lo envía al repositorio llamando a AlquilerRepository.Agregar(alquiler).

3\. \*\*Repositorio:\*\* verifica que haya unidades disponibles de cada elemento para esas fechas. Si no alcanzan, devuelve un error y el formulario se lo muestra al cliente. Si hay disponibilidad, calcula el total y asigna el estado Pendiente.

4\. \*\*Contexto (Entity Framework Core):\*\* el repositorio agrega el alquiler al AlquileresContext y ejecuta SaveChanges().

5\. \*\*Base de datos:\*\* Entity Framework Core traduce la operación a sentencias INSERT y guarda el alquiler y sus detalles en las tablas correspondientes.

6\. \*\*Respuesta:\*\* el formulario informa que la reserva se registró y abre WhatsApp con el detalle para coordinar el pago.



Cuando el empleado confirma la reserva, el recorrido es el mismo: el formulario llama al repositorio, que ejecuta el método Confirmar del alquiler y guarda el cambio con SaveChanges().





