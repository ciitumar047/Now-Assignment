->dotnet new sln -n Assignment
->dotnet new webapi -n Assignment.Api
->dotnet new classlib -n Assignment.Application
->dotnet new classlib -n Assignment.Domain
->dotnet new classlib -n Assignment.Infrastructure

Assignment.Api
->dotnet add Assignment.Api package Microsoft.AspNetCore.Authentication.JwtBearer
->dotnet add Assignment.Api package MediatR
->dotnet add Assignment.Api package Dapper

Assignment.Application
->dotnet add Assignment.Application package MediatR
->dotnet add Assignment.Application package FluentValidation

Assignment.Infrastructure
->dotnet add Assignment.Infrastructure package Dapper
->dotnet add Assignment.Infrastructure package Microsoft.Extensions.Configuration
->dotnet add Assignment.Infrastructure package Microsoft.Extensions.DependencyInjection
->dotnet add Assignment.Infrastructure package Microsoft.Data.SqlClient



Key featue of this project.
->ASP.NET Core 8 WebApi
->CQRS with MediatR Library
->Clean Architecture
->Dapper Command Side
->EF Core Query Side
->SQL db
->Repository Pattern
->JWT Auth
->Fluent validation
->global using MediatR;
