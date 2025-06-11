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
2. Ingresa a la carpeta: 
```bash
cd TallerIDWM
```
3. appsettings.json: añade esto a tu appsettings.json
```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  },
  "JWT": {
    "SigningKey": "<Tu_Clave_Secreta>",
    "Issuer": "localhost:7164",
    "Audience": "localhost:7164"
  },

  "Cloudinary": {
  "CloudName": "<nombre de cloudinary>",
  "ApiKey": "<tu_apikey>",
  "ApiSecret": tu_apisecret>""
  },

  "CorsSettings": {
    "AllowedOrigins": [
      "https://localhost:7164",
      "https://mi-ecommerce-frontend.com"
    ],
    "AllowedMethods": [ "GET", "POST", "PUT", "DELETE", "PATCH" ],
    "AllowedHeaders": [ "Content-Type", "Authorization" ]
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "Microsoft.AspNetCore.Hosting.Diagnostics": "Error",
        "Microsoft.Hosting.Lifetime": "Information",
        "System": "Error"
      }
    },
    "Enrich": [ "FromLogContext", "WithMachineName", "WithThreadId" ],
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log-.txt",
          "rollingInterval": "Day",
          "restrictedToMinimumLevel": "Information"
        }
      }
    ]
```
4. Restaura paquetes:
```bash
dotnet restore
```
5. Ejecuta el proyecto:
```bash
dotnet run
```

## 🧪 Datos de Prueba

El archivo DbInitializer.cs genera datos falsos al iniciar el proyecto si no hay datos existentes.

## 🧑‍💻 Autores

Gabriel López - gabriel.lopez@alumnos.ucn.cl - 21.583.391-7  
Vicente Ordenes - vicente.ordenes@alumnos.ucn.cl - 20.941.890-8
