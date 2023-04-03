# StudentsManagementAPI

This project is a simple API built using ASP.NET Core that allows users to manage student records. It provides endpoints for creating, retrieving, updating, and deleting students.

# Getting Started
To get started with this project, clone the repository to your local machine and open it in your preferred development environment. You'll need to have .NET Core installed on your machine to run the project.

# Endpoints
The API provides the following endpoints:

GET /api/students - Retrieves a list of all students <br>
GET /api/students/{id} - Retrieves a specific student by ID <br>
POST /api/students - Creates a new student <br>
PUT /api/students/{id} - Updates an existing student <br>
DELETE /api/students/{id} - Deletes a student <br>

# The API uses the following dependencies:

AutoMapper - for mapping between data model objects and DTOs
Microsoft.EntityFrameworkCore - for working with a database
Microsoft.EntityFrameworkCore.SqlServer - for working with a SQL Server database
Microsoft.EntityFrameworkCore.Tools - for generating database migrations

# Conclusion
This project provides a simple example of building an API using ASP.NET Core, with CRUD functionality for managing student records. It can be used as a starting point for building more complex APIs with additional features and functionality.
