[# MechanicShop – Workshop Management System

### Full-Stack Showcase Project | ASP.NET Core | Blazor WebAssembly | Clean Architecture

MechanicShop is a workshop management system developed as a full-stack **showcase project** to demonstrate modern backend architecture, clean design principles, and real-time communication in a business-oriented domain.

The project focuses on building a scalable, maintainable, and well-structured system for managing automotive repair workflows while applying industry best practices.

---

## Architecture Overview

MechanicShop follows **Clean Architecture** and **Domain-Driven Design (DDD)** principles to ensure clear separation of concerns, testability, and long-term maintainability.

### Architectural Patterns Used
- Clean Architecture (Presentation, Application, Domain, Infrastructure)
- Domain-Driven Design (DDD)
- CQRS-style separation for commands and queries
- Real-time communication using SignalR
- Modular, microservices-ready structure

---

## Core Features

### Workflow and Operations
- Work order creation and lifecycle management  
- Task and repair workflow orchestration  
- Real-time status updates using SignalR  
- Workshop capacity and repair spot management  
- Technician workload and assignment tracking  

### Billing and Finance
- Extensible billing and invoicing design  
- Discount, tax, and pricing rule support  
- Repair cost calculation and tracking  

### Business Management
- Parts inventory and availability tracking  
- Supplier and pricing management  
- Structured audit logging  

---

## Technical Stack

| Layer | Technologies |
|------|--------------|
| Backend | ASP.NET Core 9.0, Entity Framework Core, MediatR, SignalR, Swagger / OpenAPI |
| Frontend | Blazor WebAssembly, Bootstrap, JavaScript |
| Database | Microsoft SQL Server |
| Observability | Serilog, OpenTelemetry |
| DevOps | Docker, GitHub Actions (CI) |

---

## Key Modules

- Repair Management – Manage repair tasks and workflows  
- Billing & Invoicing – Flexible and extensible billing logic  
- Inventory – Parts, suppliers, and pricing management  
- Real-Time Updates – Live updates via SignalR  
- Administration – Configuration and system management  

---

## 🗂 Project Structure

The solution is organized using **Clean Architecture** principles:

```
MechanicShop/
│
├── MechanicShop.sln
├── README.md
├── Dockerfile
├── docker-compose.yml
├── Directory.Build.props
├── Directory.Packages.props
│
├── src/
│   ├── MechanicShop.Api/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Controllers/
│   │   ├── Components/
│   │   ├── Middlewares/
│   │   ├── Extensions/
│   │   └── Hubs/
│   │
│   ├── MechanicShop.Application/
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   ├── DTOs/
│   │   ├── Features/
│   │   └── DependencyInjection.cs
│   │
│   ├── MechanicShop.Domain/
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   ├── Enums/
│   │   └── Exceptions/
│   │
│   ├── MechanicShop.Infrastructure/
│   │   ├── Data/
│   │   │   ├── DbContexts/
│   │   │   ├── Configurations/
│   │   │   └── Migrations/
│   │   ├── Repositories/
│   │   ├── Identity/
│   │   ├── RealTime/
│   │   └── DependencyInjection.cs
│   │
│   └── MechanicShop.Client/
│       ├── Components/
│       ├── Common/
│       ├── Routes.razor
│       ├── _Imports.razor
│       └── wwwroot/
│
└── tests/
    ├── MechanicShop.UnitTests/
    └── MechanicShop.IntegrationTests/
```

---
## Quality and Testing

- Unit and integration tests using xUnit  
- Application-layer testing with minimal infrastructure coupling  
- Centralized validation and error handling  
- Environment-specific configurations  

---

## DevOps and Infrastructure

- Docker containerization for consistent environments  
- Centralized structured logging using Serilog  
- Metrics and tracing via OpenTelemetry  
- CI pipeline using GitHub Actions  

---

## Design Goals

- Demonstrate scalable backend architecture  
- Apply Clean Architecture and SOLID principles  
- Enable real-time system communication  
- Provide a foundation for future expansion  
- Emphasize code clarity and maintainability  

---

## Best Practices Followed

- Clean Architecture  
- SOLID Principles  
- Domain-Driven Design (DDD)  
- Centralized validation and error handling  
- Secure-by-design approach  
- Logging and observability  

---

## Future Enhancements

- Role-based authorization  
- Analytics and KPI dashboards  
- Payment gateway integration  
- Mobile-friendly client UI  
- Predictive reporting features  

---

## Installation and Setup

### Prerequisites
- .NET 9.0 SDK  
- SQL Server  
- Docker Desktop (optional)  

### Steps

```bash
git clone https://github.com/yourusername/MechanicShop.git
cd MechanicShop
dotnet restore
dotnet build
dotnet run
](https://github.com/engabdallah123/Setup-App-Clean-Architecture-And-CQRS)
