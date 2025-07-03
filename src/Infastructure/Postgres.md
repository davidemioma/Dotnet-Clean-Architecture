# Using PostgreSQL with EF Core in Clean Architecture

This guide explains how to set up PostgreSQL with Entity Framework Core in a Clean Architecture .NET project.

---

## Prerequisites

- Install PostgreSQL from [https://www.postgresql.org/download/](https://www.postgresql.org/download/)
- Create a database and user (example: database `books-db`, user `postgres`, password `password`)

---

## Install Required NuGet Packages

Run these commands in your Infrastructure and Presentation projects as needed:

```bash
dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

## Install EF Core Tools

If you haven't already, install the EF Core CLI tools globally:

```bash
dotnet tool install --global dotnet-ef
```

---

## Add Connection String

Add your PostgreSQL connection string to `appsettings.json` in the Presentation project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=books-db;Username=postgres;Password=password"
}
```

---

## Adding Migrations

To add a new migration and store it in the Infrastructure project (where your AppDbContext is), run the following command from the Infrastructure directory:

```bash
cd src/Infastructure

dotnet ef migrations add "name" --startup-project ../Presentation
```

- This command creates the migration files in the Infrastructure project.
- The `--startup-project ../Presentation` flag tells EF Core to use the Presentation project for configuration (connection string, DI, etc.).

---

## Updating the Database

To apply the migrations and update your PostgreSQL database, use:

```bash
dotnet ef database update --startup-project ../Presentation
```

- This ensures EF Core uses the Presentation project for configuration when applying migrations.

---

**Note:** Always use the `--startup-project ../Presentation` flag for both migration and update commands in a Clean Architecture setup, since your configuration and DI are set up in the Presentation layer.

---

**Happy coding!**
