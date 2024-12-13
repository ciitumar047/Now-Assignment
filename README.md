dotnet new sln -n Assignment

dotnet new webapi -n Assignment.Api

dotnet new classlib -n Assignment.Application

dotnet new classlib -n Assignment.Domain

dotnet new classlib -n Assignment.Infrastructure

dotnet sln Assignment.sln add Assignment.Api/Assignment.Api.csproj

dotnet sln Assignment.sln add Assignment.Application/Assignment.Application.csproj

dotnet sln Assignment.sln add Assignment.Domain/Assignment.Domain.csproj

dotnet sln Assignment.sln add Assignment.Infrastructure/Assignment.Infrastructure.csproj

Assignment.Api
dotnet add Assignment.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add Assignment.Api package MediatR
dotnet add Assignment.Api package Dapper

Assignment.Application
dotnet add Assignment.Application package MediatR
dotnet add Assignment.Application package FluentValidation

Assignment.Infrastructure
dotnet add Assignment.Infrastructure package Dapper
dotnet add Assignment.Infrastructure package Microsoft.Extensions.Configuration
dotnet add Assignment.Infrastructure package Microsoft.Extensions.DependencyInjection
dotnet add Assignment.Infrastructure package Microsoft.Data.SqlClient

global using MediatR;

key featue of this project.
ASP.NET Core 8 WebApi
CQRS with MediatR Library
Clean Architecture
Dapper Command Side
EF Core Query Side
SQL db
Repository Pattern
Options Pattern
JWT Auth
Fluent validation
