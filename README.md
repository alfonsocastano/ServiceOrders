# Prueba Técnica – Sistema de Gestión de Órdenes de Servicio

## Descripción

Este proyecto corresponde al desarrollo de una API para la gestión de órdenes de servicio de una empresa de mantenimiento.

La solución permite administrar clientes, técnicos y órdenes de servicio, además de implementar autenticación basada en JWT para proteger los endpoints de la aplicación.

El proyecto fue desarrollado utilizando .NET, Dapper y PostgreSQL.

La base de datos se puede seleccionar por medio de configuración, así se elige entre  PostgreSQL u Oracle.

---

## Tecnologías utilizadas

* .NET 8
* ASP.NET Core Web API
* Dapper
* PostgreSQL
* Oracle
* JWT Authentication
* Swagger
* Git

---

## Arquitectura

La solución se encuentra basada en Clear Architecture y está organizada en la siguiente estructura de capas:

```text
ServiceOrders.Api
ServiceOrders.Application
ServiceOrders.Domain
ServiceOrders.Infrastructure
ServiceOrders.Tests
```

### Responsabilidades

**Domain**

Contiene las entidades y reglas principales del negocio.

**Application**

Contiene DTOs, interfaces y servicios de aplicación.

**Infrastructure**

Implementa acceso a datos, autenticación JWT y persistencia mediante Dapper.

**Api**

Expone los endpoints REST y configura los componentes de la aplicación.

**Tests**

Pendiente...

---

## Funcionalidades implementadas

### Autenticación

* Login mediante usuario y contraseña.
* Generación de token JWT.
* Validación de sesión.
* Endpoint para obtener información del usuario autenticado.

### Clientes

* Crear cliente.
* Consultar clientes.
* Actualizar cliente.
* Eliminar cliente mediante Soft Delete.

### Técnicos

* Crear técnico.
* Consultar técnicos.
* Actualizar técnico.
* Eliminar técnico mediante Soft Delete.

### Órdenes de Servicio

* Crear órdenes.
* Consultar órdenes.
* Actualizar órdenes.
* Eliminar órdenes mediante Soft Delete.
* Cambio de estado.
* Asociación con cliente y técnico.

### Filtros

Se implementó construcción dinámica de consultas SQL utilizando Dapper para soportar filtros combinables por:

* Estado.
* Cliente.
* Técnico.
* Documento del cliente.
* Especialidad del técnico.
* Fecha de inicio.
* Fecha de fin

---

## Configuración de Base de Datos

La aplicación permite cambiar entre PostgreSQL y Oracle mediante configuración, aúnque en esta solución solo se implemento PostgreSQL.

### PostgreSQL

```json
{
  "DatabaseSettings": {
    "Provider": "PostgreSql"
  }
}
```

### Oracle

```json
{
  "DatabaseSettings": {
    "Provider": "Oracle"
  }
}
```

---

## Usuario Inicial

```text
Usuario: admin
Contraseña: Admin123*
```

---

## Ejecución

Abrir la solución en Visual Studio, Restaurar dependencias o por linea de comandos:

```bash
dotnet restore
```

Compilar solución o por linea de comandos:

```bash
dotnet build
```

Ejecutar F5 o por linea de comandos:

```bash
dotnet run
```

---

## Swagger

Una vez iniciada la aplicación, acceder a:

```text
https://localhost:7097/swagger
```

1. Ejecutar el endpoint de login.
2. Copiar el token generado.
3. Seleccionar Authorize.
4. Ingresar:

```text
Bearer {token}
```

5. Consumir los endpoints protegidos.

---

## Consideraciones

* Se utilizó Dapper como mecanismo principal de acceso a datos.
* Se implementó Soft Delete para las entidades principales.
* Se utilizó JWT para la protección de endpoints.
* La persistencia fue desacoplada para soportar PostgreSQL y Oracle mediante configuración.
