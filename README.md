# AgencyTax Microservice API

AgencyTax is a RESTful microservice built with ASP.NET Core and C# that manages invoice data and tax reporting.

## Tech Stack

ASP.NET Core  
C#  
Entity Framework Core  
SQL Server  
xUnit + Moq  
Swagger  

## Features

- Create invoices with automatic tax calculation
- Store invoice data in SQL Server
- Generate monthly revenue and tax reports
- Input validation using DataAnnotations
- Domain-level business rule validation
- Global exception middleware
- Structured request logging
- Unit testing for service logic

## Architecture

Controller → Service → Repository

This layered architecture separates:

- HTTP request handling
- business logic
- data persistence

## Example Endpoints

POST /api/invoices  
Create a new invoice and calculate tax totals.

GET /api/invoices/report  
Return monthly revenue and tax summary.

## Purpose

This project demonstrates enterprise backend patterns used in .NET microservices including:

- dependency injection
- exception middleware
- service layer architecture
- structured logging
