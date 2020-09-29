El API Basicamente lo que hace es hacer los solicitudes a la base de datos
Se omitio el uso de tokens o loggins
Se esta utilizando DataBase First 
En el proyecto de TareasWebApi estan los scripts para la base de datos en SQL Server Version 2014
Se implementan Store Procedures Models/Services/TareasServicios y ColaboradorServicios
Los controllers hacen uso de los servicios de los store procedures
Se crean modelos personalizados para cada store procedure
Se agregan los servicios en el startup
Se agrega la conexion de la base de datos en el startup
Se configuran los permisos Cross-Origin Requests (CORS) 
Se agrega el uso de Swagger UI para el manejo del API
