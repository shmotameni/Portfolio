IT Service Management Platform

Portfolio is a web-based IT Service Management platform developed with C# and ASP.NET Core Web API. The project demonstrates my experience in backend development, REST APIs, software architecture, database development, testing, and clean code practices.

The main goal is to build a realistic IT service platform where users can create and manage IT tickets, track their status and priority, and manage IT-related resources.

Features:
* Create and manage IT tickets
* Ticket status management
* Ticket priority management
* User management
* IT asset management
* Ticket assignment
* Ticket comments and history
* Dashboard and statistics
* RESTful API
* Authentication and authorization
* Input validation and error handling
* Unit testing
  
Technologies:
* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* REST API
* Swagger / OpenAPI
* Git & GitHub
* xUnit
* Docker
* CI/CD
  
Architecture
The project follows a Clean Architecture-inspired structure with a clear separation between the different responsibilities of the application.

Portfolio
│
├── Controllers
│
├── Domain
│   ├── Entities
│   └── Enums
│
├── Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Infrastructure
│   └── Data
│
└── Program.cs

The architecture is designed to keep business logic separated from the API and infrastructure components and to make the application easier to maintain and test.

Ticket Workflow

Tickets follow a simple workflow:

Open
  ↓
InProgress
  ↓
WaitingForUser
  ↓
Resolved
  ↓
Closed

Tickets can have different priorities:

Low
Medium
High
Critical

API Example
Create a new ticket:

POST /api/Tickets

Example request:
{
  "title": "Laptop cannot connect to the company network",
  "description": "The user cannot access the internal network.",
  "priority": "High"
}

Project Goals

This project is being developed as a portfolio project to demonstrate practical skills in:

* Backend development with C# and .NET
* REST API design
* Object-oriented programming
* Clean Code and SOLID principles
* Entity Framework Core
* SQL Server
* Dependency Injection
* Unit Testing
* Git and GitHub
* Software architecture
* Agile development practices
* Future Improvements

Planned improvements include:
* React / TypeScript frontend
* JWT authentication
* Role-based authorization
* Advanced ticket filtering and search
* Email notifications
* IT asset management
* Dashboard with statistics
* Docker containerization
* CI/CD pipeline
* Additional automated tests

Sharmin Motameni
C# / .NET Developer

This project is part of my professional software development portfolio.
