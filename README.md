# .NET Clean Architecture Template

A starting point for building scalable, maintainable, and testable .NET applications using the Clean Architecture pattern.

---

## Project Structure

```
src/
  Domain/         # Core business logic and entities
  Application/    # Application use cases and interfaces
  Infastructure/  # Data access and external service implementations
  Presentation/   # Web API (entry point)
```

---

## Getting Started

Follow these steps to set up the solution:

### 1. Create the Solution

```bash
dotnet new sln -n YourSolutionName
mkdir src
cd src
```

### 2. Create the Projects

- **Domain** (Core business logic and entities)

  ```bash
  dotnet new classlib -n Domain
  ```

  This is where you add your entities for the database, such as `Book.cs`:

  ```csharp
  namespace Domain.Entities
  {
      public class Book
      {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Author { get; set; }
          public int YearPublished { get; set; }
      }
  }
  ```

- **Application** (Use cases, interfaces, business rules)

  ```bash
  dotnet new classlib -n Application
  ```

- **Infrastructure** (Database and external service implementations)

  ```bash
  dotnet new classlib -n Infastructure
  ```

- **Presentation** (Web API)
  ```bash
  dotnet new webapi -n Presentation
  ```

### 3. Add Project References

- **Application** depends on **Domain**:

  ```bash
  dotnet add Application/Application.csproj reference Domain/Domain.csproj
  ```

- **Infastructure** depends on **Domain**:

  ```bash
  dotnet add Infastructure/Infastructure.csproj reference Domain/Domain.csproj
  ```

- **Presentation** depends on **Application** and **Infastructure**:
  ```bash
  dotnet add Presentation/Presentation.csproj reference Application/Application.csproj
  dotnet add Presentation/Presentation.csproj reference Infastructure/Infastructure.csproj
  ```

### 4. Add Projects to the Solution

After creating your projects, add them to your solution file using the following commands. Replace `YourSolutionName.sln` with the actual name of your solution file (check your project root for the correct name):

```bash
dotnet sln YourSolutionName.sln add src/Domain/Domain.csproj
dotnet sln YourSolutionName.sln add src/Application/Application.csproj
dotnet sln YourSolutionName.sln add src/Infastructure/Infastructure.csproj
dotnet sln YourSolutionName.sln add src/Presentation/Presentation.csproj
```

```bash
dotnet restore
dotnet build
```

> **Note:** If your solution file has an unusual name (like `..sln`), you can rename it for clarity:
>
> ```bash
> mv ..sln YourSolutionName.sln
> ```
>
> Then use the new name in the commands above.

---

## Summary

- **Domain**: Contains core entities and business logic.
- **Application**: Contains use cases and interfaces; depends on Domain.
- **Infastructure**: Implements data access and external services; depends on Application and Domain.
- **Presentation**: The Web API entry point; depends on Application and Infastructure.

---

## Next Steps

- Implement your domain entities and business rules in the `Domain` project.
- Add use cases and interfaces in the `Application` project.
- Set up data access and external integrations in the `Infastructure` project.
- Build your API endpoints in the `Presentation` project.

---

```

```
