# Proyecto API en C# con SQL

Este proyecto es una API RESTful creada con C# y Entity Framework Core para interactuar con una base de datos SQL Server.

## Tabla de Contenidos


## Requisitos

- .NET SDK 6.0 o superior
- SQL Server
- Visual Studio 2019/2022 o Visual Studio Code

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/tu-repositorio.git
   cd tu-repositorio
Restaura los paquetes NuGet:

bash
Copiar código
dotnet restore
Configuración
Configura la cadena de conexión a la base de datos en appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=TU-SERVIDOR; Initial Catalog=TU-BASE-DE-DATOS; Integrated Security=true; Trusted_Connection=True; MultipleActiveResultSets=True; Encrypt=false"
  }
}
En Program.cs, asegúrate de que el servicio DbContext esté configurado correctamente:

csharp
Copiar código
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
Uso
Ejecuta la aplicación:

bash
Copiar código
dotnet run
La API estará disponible en https://localhost:5001 o http://localhost:5000.

Migraciones
Crear una nueva migración:

bash
Copiar código
dotnet ef migrations add NombreMigracion
Actualizar la base de datos:

bash
Copiar código
dotnet ef database update
Endpoints
GET /api/categorias: Obtiene todas las categorías.
GET /api/categorias/{id}: Obtiene una categoría por ID.
POST /api/categorias: Crea una nueva categoría.
PUT /api/categorias/{id}: Actualiza una categoría existente.
DELETE /api/categorias/{id}: Elimina una categoría por ID.
GET /api/productos: Obtiene todos los productos.
GET /api/productos/{id}: Obtiene un producto por ID.
POST /api/productos: Crea un nuevo producto.
PUT /api/productos/{id}: Actualiza un producto existente.
DELETE /api/productos/{id}: Elimina un producto por ID.
Contribución
¡Contribuciones son bienvenidas! Por favor, abre un issue o envía un pull request.

![1](https://github.com/DavidCondoriAguilar/ServicioRestCore/assets/103283145/519b3ef3-e8c1-4031-be13-64da4d30c827)

