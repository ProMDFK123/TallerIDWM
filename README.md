# TallerIDWM

Este repositorio corresponde al Taller de la asignatura Introducción al Desarrollo Web/Móvil, el cual consiste en realizar un e-commerce basado en una arquitectura cliente-servidor

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
2. Entra en la carpeta del proyecto:
```bash
cd TallerIDWM/api
```
3. Restaura paquetes:
```bash
dotnet restore
```
4. Aplica las migraciones:
```bash
   dotnet ef database update
```
5. Ejecuta el proyecto:
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
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── Models/
│   ├── DTOs/
│   ├── Data/
│   ├── Interfaces/
│   └── Program.cs
├── README.md
└── launchSettings.json
</pre>

## 🧑‍💻 Autores

Gabriel López - https://github.com/ProMDFK123  
Vicente Ordenes - https://github.com/yakusu123
