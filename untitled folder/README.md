# NLayerApp - ASP.NET Core N-Layer Architecture

A sample ASP.NET Core Web API application demonstrating n-layer architecture with proper separation of concerns.

## Project Structure

```
NLayerApp/
├── API/                    # Presentation Layer (Web API)
│   ├── Controllers/        # API controllers
│   ├── DTOs/              # Data Transfer Objects
│   └── Program.cs         # Application entry point
├── Business/              # Business Logic Layer
│   ├── Interfaces/        # Service interfaces
│   └── Services/          # Service implementations
├── Core/                  # Domain Layer
│   ├── Entities/          # Domain entities
│   └── Interfaces/        # Core interfaces (IRepository, IUnitOfWork)
└── DAL/                   # Data Access Layer
    ├── Data/              # DbContext
    ├── Repositories/      # Repository implementations
    └── UnitOfWork/        # Unit of Work implementation
```

## Architecture Layers

### API Layer (Presentation)

- RESTful API controllers
- Request/Response DTOs
- Dependency injection configuration
- Swagger documentation

### Business Layer

- Business logic and rules
- Service interfaces and implementations
- Orchestrates operations between API and DAL

### Core Layer (Domain)

- Domain entities (BaseEntity, Product)
- Core interfaces (IRepository, IUnitOfWork)
- No dependencies on other layers

### DAL Layer (Data Access)

- Entity Framework Core DbContext
- Generic repository pattern implementation
- Unit of Work pattern implementation
- Database operations

## Dependencies Flow

```
API → Business → DAL → Core
```

Each layer only depends on layers below it, ensuring clean separation of concerns.

## Technologies

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Entity Framework Core 9.0** (In-Memory Database)
- **Swagger/OpenAPI** for API documentation

## Getting Started

### Prerequisites

- .NET 9.0 SDK

### Build the Solution

```bash
dotnet build
```

### Run the Application

```bash
cd API
dotnet run
```

The API will be available at:

- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### Access Swagger UI

Navigate to: `https://localhost:5001/swagger`

## API Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update an existing product
- `DELETE /api/products/{id}` - Delete a product
- `GET /api/products/search?searchTerm={term}` - Search products

### Sample Request (Create Product)

```json
POST /api/products
{
  "name": "Sample Product",
  "description": "Product description",
  "price": 29.99,
  "stock": 100
}
```

## Design Patterns Used

1. **Repository Pattern**: Abstracts data access logic
2. **Unit of Work Pattern**: Manages transactions and coordinates multiple repositories
3. **Dependency Injection**: Loosely coupled components
4. **DTO Pattern**: Separates API contracts from domain entities

## Database

Currently using **Entity Framework Core In-Memory Database** for development and testing.

### To Use SQL Server

1. Update connection string in `appsettings.json`
2. Replace `UseInMemoryDatabase` with `UseSqlServer` in [Program.cs](API/Program.cs)
3. Run migrations:
   ```bash
   cd DAL
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Project Benefits

- **Separation of Concerns**: Each layer has a distinct responsibility
- **Testability**: Easy to unit test each layer independently
- **Maintainability**: Changes in one layer don't affect others
- **Scalability**: Easy to add new features and entities
- **Flexibility**: Can swap implementations (e.g., different databases)

## Development

### Adding New Entities

1. Create entity in `Core/Entities/`
2. Add DbSet in `ApplicationDbContext`
3. Create service interface in `Business/Interfaces/`
4. Implement service in `Business/Services/`
5. Create DTOs in `API/DTOs/`
6. Create controller in `API/Controllers/`

## License

This is a sample project for educational purposes.
