# TallerIDWM

Este repositorio corresponde al Taller de la asignatura Introducción al Desarrollo Web/Móvil, el cual consiste en realizar un e-commerce basado en una arquitectura cliente-servidor, utilizando para ello una API REST.

## 🛠️ Tecnologías

- .NET 9.0
- Entity Framework Core
- Bogus (generación de datos)
- SQLite
- ASP.NET Core Web API

## 📦 Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/ProMDFK123/TallerIDWM.git
```
2. Restaura paquetes:
```bash
dotnet restore
```
3. Aplica las migraciones:
```bash
dotnet ef database update
```
4. Ejecuta el proyecto:
```bash
dotnet run
```

## 🧪 Datos de Prueba

El archivo DbInitializer.cs genera datos falsos al iniciar el proyecto si no hay datos existentes.

## 📁 Estructura del Proyecto

<pre>
TallerIDWM/
│
├── api/
│   ├── src/
│   │   ├── Controllers/
│   │   ├── Services/
│   │   ├── Extensions/
│   │   ├── Helpers/
│   │   ├── Mappers/
│   │   ├── RequestHelpers/
│   │   ├── Repositories/
│   │   ├── Models/
│   │   ├── DTOs/
│   │   ├── Data/
│   │   └── Interfaces/
│   └── Program.cs
├── README.md
└── Properties/
    └── launchSettings.json
</pre>

## 🧑‍💻 Autores

Gabriel López - gabriel.lopez@alumnos.ucn.cl - 21.583.391-7  
Vicente Ordenes - vicente.ordenes@alumnos.ucn.cl - 20.941.890-8
