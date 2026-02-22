Sistema de Horarios dinámicos

¿Como usar?

1-	Base de datos:

Lo primero antes de todo es entender como funciona la base de datos, se utilizó migraciones para crear la base de datos desde Visual Studio hasta SQL Server.
En este punto aunque tenga la codificación no tiene la base de datos, tiene dos maneras de obtenerla:
A)	Borrar la carpeta Migrations en el explorador de soluciones:

<img width="209" height="198" alt="Borrar migrations" src="https://github.com/user-attachments/assets/01647a99-5023-4d36-a9f8-5f6da0759d74" />

Luego de eliminarla, debe abrir la consola de paquetes: 
Debe ir a Herramientas o Tools/Administrador de paquetes NuGet/Consola de administración de paquetes
Luego debe crear una nueva Migración en su terminar ejecutar: Add-Migration InitialCreate y luego de que termine debe ejecutar Update-Database.

Esto hará que se cree la base de datos, ojo… Debe tener instalado SQL Server para que todo esto funcione correctamente.

B)	Crear la base de datos directa: Con el archivo .sql puede crear la base de datos directamente en su Sql server, solo es copiar y pegar en una nueva consulta, al ejecutar se le generará la base de datos llamada SistemaHorariosDB.

2-	API

Primero se ejecuta la Api (Nombre: SistemaHorarios que se encuentra en la carpeta SistemaHorariosAPI).

<img width="797" height="57" alt="Api ejecutar" src="https://github.com/user-attachments/assets/22ab4392-04c7-4299-a5d2-89d8ec86a0ed" />

1.	Validamos que estamos en SistemaHorarios.
2.	Una vez verificado, continuamos con la ejecución de la API (Botón verde Https)
3.	Se abrirá un navegador con una web llamada SWAGGER

<img width="951" height="366" alt="swagger" src="https://github.com/user-attachments/assets/cd0b9ef9-7559-4ffe-b68f-bbeb2b286113" />

Esto valida que la API está activa.


3.1.	 También se nos abrirá una consola:

<img width="660" height="111" alt="Consola" src="https://github.com/user-attachments/assets/f810c073-839e-4850-a8f8-87d5ba4cdebe" />


Esta consola nos dará una información muy importante y es el puerto de conexión de la API, en mi caso es el 7208, pero si cambia, debe usarse el que le proporciona la API.



3-	Sistema WEB/Horarios:
Al abrir la solución, lo primero que debemos ubicar es el archivo Program.cs:

<img width="198" height="168" alt="programs" src="https://github.com/user-attachments/assets/38ec0038-24aa-4c08-9ecb-64203cca0a09" />

En la codificación, observamos el localhost y cambiamos el puerto por el del api mencionado anteriormente. Está comentado la instrucción para mejor visualización.

<img width="546" height="107" alt="puerto" src="https://github.com/user-attachments/assets/7694ac30-6a18-47f4-8aed-0a58459466fb" />


Una vez validada esta parte, solo se debe de ejecutar el proyecto:

<img width="817" height="55" alt="sistemaweb" src="https://github.com/user-attachments/assets/431e3d56-a8cf-4200-8154-f361bae33f5c" />

1.	Validamos que estamos en el SistemaHorario.Web.
2.	Ejecutamos el proyecto (Botón verde Https)
Nota: Si no está ejecutada la API, el proyecto web se abrirá, pero con un error, debe iniciar primero la API y luego abrir el proyecto web.


Se abrirá el navegador automáticamente con la web. Aquí observaremos esto:

<img width="960" height="507" alt="Paginaweb" src="https://github.com/user-attachments/assets/ae058227-9352-438d-b617-e855a44f48d7" />


Tiene datos ya creados de debug. El horario es dinámico, lo cual se irá rellenando a medida que se creen las clases.
También se abrirá otra terminal:

<img width="947" height="494" alt="terminal web" src="https://github.com/user-attachments/assets/97f083e1-ebeb-4d47-bd0e-fd3777597eab" />

En la parte superior observaremos un pequeño menú donde se dividen las siguientes opciones: Inicio, Docentes, Asignaturas, Aulas y Grupos.

Inicio: es la parte que se muestra arriba, donde está el calendario.

Docentes:
Es la pantalla donde se mostrará la información del Docente.

<img width="960" height="446" alt="docente pantalla" src="https://github.com/user-attachments/assets/fc14537c-23f2-46e8-b01e-4503a4152aae" />


Para añadir uno nuevo solo se le debe dar un click en el botón Nuevo Docente lo cual abrirá esta opción:

<img width="960" height="354" alt="agregar nuevo docente" src="https://github.com/user-attachments/assets/e09f9dcd-d52a-48af-a793-ce2998110fe8" />

Se llenan los valores como en el ejemplo. Y se le indica en el botón Guardar para que se almacene en la base de datos. Lo cual mostrará la anterior pantalla de esta manera:

<img width="960" height="310" alt="Agregado docente" src="https://github.com/user-attachments/assets/664c69d2-6247-4b1c-8b85-c24be2d77e0b" />

Nota: Se puede eliminar al docente en la sección de Acciones.

Asignaturas:
Es la pantalla donde se mostrarán las informaciones de las asignaturas.

<img width="960" height="274" alt="Asignatura pantalla" src="https://github.com/user-attachments/assets/83c8fed2-adee-4e82-b968-ef4f419fd56d" />

Para añadir uno nuevo solo se le debe dar un click en el botón Nueva Asignatura lo cual abrirá esta opción:

<img width="960" height="296" alt="crear asignatura" src="https://github.com/user-attachments/assets/46ed6923-2dbb-4385-8618-5ef351360db5" />

Se llenan los valores como en el ejemplo. Y se le indica en el botón Guardar para que se almacene en la base de datos. Lo cual mostrará la anterior pantalla de esta manera:

<img width="960" height="313" alt="Asignatura creada" src="https://github.com/user-attachments/assets/848958e4-4dd5-413f-9974-9076d237dca2" />

Nota: Se puede eliminar la asignatura en la sección de Acciones.

Aulas:
Es la pantalla donde se mostrarán las informaciones de las Aulas.

<img width="960" height="275" alt="Aulas pantalla" src="https://github.com/user-attachments/assets/3653005a-aec6-4822-bbcc-698025ae9ab5" />

Para añadir uno nuevo solo se le debe dar un click en el botón Nueva Aula lo cual abrirá esta opción:

<img width="960" height="295" alt="Crear Aula" src="https://github.com/user-attachments/assets/96f6b938-568c-4a03-b501-6b368505ca4d" />

Se llenan los valores como en el ejemplo. Y se le indica en el botón Guardar para que se almacene en la base de datos. Lo cual mostrará la anterior pantalla de esta manera:

<img width="960" height="310" alt="aula creada" src="https://github.com/user-attachments/assets/7fa0ca77-74cb-4a05-a774-eda62b865a5f" />

Nota: Se puede eliminar el aula en la sección de Acciones.


Grupos:
Es la pantalla donde se mostrarán las informaciones de los grupos.

<img width="960" height="279" alt="Grupos pantalla" src="https://github.com/user-attachments/assets/d8ec3af6-75d7-49ab-8850-e92ac5a690c7" />

Para añadir uno nuevo solo se le debe dar un click en el botón Nuevo Grupo lo cual abrirá esta opción:

<img width="960" height="295" alt="crear grupos" src="https://github.com/user-attachments/assets/8c0616e8-5626-4630-8424-d7e2898d09ec" />

Se llenan los valores como en el ejemplo. Y se le indica en el botón Guardar para que se almacene en la base de datos. Lo cual mostrará la anterior pantalla de esta manera:

<img width="960" height="310" alt="Grupos creados" src="https://github.com/user-attachments/assets/ffb51fa1-1767-404a-9547-472d81e0e97a" />

Nota: Se puede eliminar los grupos en la sección de Acciones.
Por último volvemos a Inicio y le damos al botón Agregar Clase, se nos abrirá esta ventana:

<img width="607" height="447" alt="Agregar nueva clase pantalla" src="https://github.com/user-attachments/assets/3c915853-40a3-4d6a-a714-5da30a5abb65" />

Si llenamos los datos con los valores que hemos creado anteriormente, nos quedaría algo como esto:

<img width="584" height="447" alt="Agregar nueva clase datos" src="https://github.com/user-attachments/assets/3728760f-52f6-44ad-b5a5-2781a0eea2b0" />

Nota: Se debe elegir la fecha y hora de la asignatura, es muy importante seleccionarla bien. Si se crea una asignatura Lunes a las 2 de la tarde hasta las 3, el martes si se crea una a la misma hora se pondrá en la misma posición, pero del martes.
Si guardamos los cambios en el botón inferior, nos quedará de esta manera:

<img width="844" height="364" alt="Agregado clase" src="https://github.com/user-attachments/assets/e1ae66fd-cd32-4e68-aeef-ca72d0f2c8b4" />











