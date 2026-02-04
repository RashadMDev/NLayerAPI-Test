# ASP.NET N-Layer Architecture Project

## Project Structure

- **API Layer**: Web API controllers and endpoints
- **Business Layer**: Business logic and services
- **Core Layer**: Domain entities and interfaces
- **DAL Layer**: Data access and Entity Framework Core implementation

## Architecture Guidelines

- Dependencies flow inward: API -> Business -> DAL -> Core
- Core has no dependencies on other layers
- Use dependency injection for loose coupling
- Repository pattern for data access
- Service pattern for business logic
