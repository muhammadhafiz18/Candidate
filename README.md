# Candidate API

A RESTful API service for managing candidate information in a recruitment system. This API allows for storing and updating candidate details including personal information, contact details, and professional profiles.

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- FluentValidation

## Prerequisites

- .NET 8 SDK
- PostgreSQL
- An IDE (Visual Studio, VS Code, or similar)

## Database Configuration

The application uses PostgreSQL as its database. Two connection string configurations are provided:(Port: 5432)

### Database Schema

The database contains a `Candidates` table with the following structure:
- `Id` (Primary Key)
- `FirstName` (Required, max 255 chars)
- `LastName` (Required, max 255 chars)
- `Email` (Required, max 255 chars, unique)
- `PhoneNumber` (Optional, max 50 chars)
- `PreferredCallTime` (Optional, max 100 chars)
- `LinkedInUrl` (Optional, max 500 chars)
- `GitHubUrl` (Optional, max 500 chars)
- `Comment` (Required, max 1000 chars)

## API Endpoints

### Upsert Candidate
- **Endpoint**: PUT `/api/candidate`
- **Description**: Creates a new candidate or updates an existing one based on email
- **Request Body**: JSON object containing candidate details
- **Responses**:
  - 201 Created (New candidate)
  - 204 No Content (Updated existing candidate)
  - 400 Bad Request (Validation errors)
  - 500 Internal Server Error

## Getting Started

1. Clone the repository
2. Start the PostgreSQL database:
3. Update the database with migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run 
   ```

## Architecture

The application follows a clean architecture pattern with the following layers:
- Controllers (API endpoints)
- Services (Business logic)
- Repositories (Data access)
- Models (Domain entities)
- DTOs (Data transfer objects)

## Features

- Email-based upsert operation
- Fluent validation
- Entity Framework Core with PostgreSQL
- Structured logging
- Clean architecture implementation

## Error Handling

The API includes:
- Validation error responses
- Structured error logging

## Configuration

Configuration can be modified through:
- `appsettings.json` for production
- `appsettings.Development.json` for development