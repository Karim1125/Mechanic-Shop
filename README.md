MechanicShop – Workshop Management System
Full-Stack Showcase Project | ASP.NET Core | Blazor WebAssembly | Clean Architecture

MechanicShop is a workshop management system developed as a full-stack showcase project to demonstrate modern backend architecture, clean design principles, and real-time communication in a business-oriented domain.

The project focuses on building a scalable, maintainable, and well-structured system for managing automotive repair workflows while applying industry best practices in software design.

Architecture Overview

MechanicShop follows Clean Architecture and Domain-Driven Design (DDD) principles to ensure clear separation of concerns, testability, and long-term maintainability.

Architectural Patterns Used

Clean Architecture (Presentation, Application, Domain, Infrastructure)

Domain-Driven Design (DDD) with rich domain models

CQRS-style separation for commands and queries

Real-time communication using SignalR

Modular, microservices-ready project structure

Core Features
Workflow and Operations

Work order creation and lifecycle management

Task and repair workflow orchestration

Real-time status updates using SignalR

Workshop capacity and repair spot management

Technician workload and assignment tracking

Billing and Finance

Extensible billing and invoicing design

Support for discounts, taxes, and pricing rules

Repair cost calculation and tracking

Business Management

Parts inventory and availability tracking

Supplier and pricing management

Structured audit logging for operations

Technical Stack
Layer	Technologies
Backend	ASP.NET Core 9.0, Entity Framework Core, MediatR, SignalR, Swagger/OpenAPI
Frontend	Blazor WebAssembly, Bootstrap, JavaScript
Database	Microsoft SQL Server
Observability	Serilog, OpenTelemetry
DevOps	Docker, GitHub Actions (CI)
Key Modules

Repair Management – Manage repair tasks and workflows

Billing & Invoicing – Flexible and extensible billing logic

Inventory – Parts, suppliers, and pricing management

Real-Time Updates – Live status updates via SignalR

Administration – Configuration and system management features

Project Structure

The solution is organized following Clean Architecture, with a clear separation between presentation, application logic, domain, and infrastructure layers.

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
│   │
│   ├── MechanicShop.Api/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Controllers/
│   │   ├── Components/
│   │   ├── Middlewares/
│   │   ├── Extensions/
│   │   └── Hubs/                     # SignalR hubs
│   │
│   ├── MechanicShop.Application/
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   ├── DTOs/
│   │   ├── Features/                 # CQRS-style use cases
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
│   │   ├── RealTime/                 # SignalR implementations
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

Quality and Testing

Unit and integration tests using xUnit

Application-layer testing with minimal infrastructure coupling

Centralized validation and error handling

Environment-specific configurations (Development / Production)

DevOps and Infrastructure

Docker containerization for consistent environments

Centralized structured logging using Serilog and Seq

Metrics and tracing via OpenTelemetry

CI pipeline using GitHub Actions

Deployment-ready configuration setup

Design Goals

Demonstrate scalable backend architecture for business applications

Apply Clean Architecture and SOLID principles in practice

Enable real-time system communication

Provide a strong foundation for future feature expansion

Emphasize code clarity, maintainability, and testability

Best Practices Followed

Clean Architecture

SOLID Principles

Domain-Driven Design (DDD)

Centralized validation and error handling

Secure-by-design approach (authentication & authorization ready)

Logging, tracing, and observability

Future Enhancements

Role-based authorization and permissions

Advanced analytics and KPI dashboards

Payment gateway integration

Mobile-friendly client interface

Predictive maintenance and reporting features

Installation and Setup
Prerequisites

.NET 9.0 SDK

SQL Server

Docker Desktop (optional, for containerized setup)

Steps
# 1. Clone the repository
git clone https://github.com/yourusername/MechanicShop.git

# 2. Navigate to the project directory
cd MechanicShop

# 3. Restore and build
dotnet restore
dotnet build

# 4. Run the application
dotnet run
