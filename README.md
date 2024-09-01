# PruebaContactar

API desarrollada en .Net Core 6

El backup de la db se encuentra en la carpeta DB de la raiz del proyecto.
Al momento de compilar el proyecto cambiar el nombre del servidor de la db(sea localhost o como lo tenga configurado) en el appsettings.json.

Autorización en los endpoints.
Para el consumo de los endpoints de Estudiantes, Materias y Notas se debe consumir primero el endpoints de Token ya que estos requieren una autenticación.
Para el consumo del enpoints TOKEN no es necesario ingresar el usuario y password que se solicita.
