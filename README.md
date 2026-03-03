# TaskAPI

API REST de gestión de tareas desarrollada con ASP.NET Core y Docker.

## Correr con Docker

docker pull dylanmendez/task-api:v1.0
docker run -p 8080:8080 dylanmendez/task-api:v1.0

## Llamada al endpoint de tareas

GET http://localhost:8080/api/Tasks