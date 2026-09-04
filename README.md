# Smart Daily Planner

Smart Daily Planner is a basic task-management web application built with ASP.NET Core MVC, C#, Entity Framework Core, and SQL Server. It allows users to create and view daily tasks, assign priorities and due dates, and update each task's status directly from the task list.

## Features

- Create daily tasks
- View tasks ordered by due date
- Add an optional task description
- Assign Low, Medium, or High priority
- Set a due date
- Change status between Pending and Completed using an inline dropdown
- Save and retrieve task data from SQL Server
- Display server-side and client-side validation messages
- Responsive Bootstrap-based interface

## Technologies Used

- ASP.NET Core MVC (.NET 10)
- C#
- Entity Framework Core 10
- SQL Server
- Razor Views
- LINQ
- Bootstrap
- HTML and CSS

## Project Architecture

The application follows the Model-View-Controller pattern:

- **Model:** `PlannerTask` defines the task data and validation rules.
- **View:** Razor pages display the task list and task form.
- **Controller:** `TasksController` processes requests and connects the views to the database.
- **Data layer:** `ApplicationDbContext` uses Entity Framework Core to communicate with SQL Server.

## Current Application Flow

1. The user opens the Tasks page.
2. `TasksController.Index()` retrieves tasks through Entity Framework Core.
3. `Index.cshtml` displays the tasks in a table.
4. The user opens the Create page and submits a new task.
5. `TasksController.Create()` validates and saves the task in SQL Server.
6. The user can change the task status from the table.
7. `TasksController.UpdateStatus()` updates `IsCompleted` and saves the change.

## Database Model

The `PlannerTasks` table contains:

| Column | Purpose |
| --- | --- |
| `Id` | Primary key |
| `Title` | Required task title |
| `Description` | Optional task details |
| `DueDate` | Task deadline |
| `Priority` | Low, Medium, or High |
| `IsCompleted` | Pending or completed status |
| `CreatedAt` | Task creation date and time |

## Setup Instructions

### Prerequisites

- Visual Studio 2026
- .NET 10 SDK
- SQL Server or SQL Server LocalDB

### 1. Clone the repository

```bash
git clone <your-repository-url>
```

Open the solution in Visual Studio.

### 2. Configure the database

Add a connection string to `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR-SERVER-NAME;Database=SmartDailyPlannerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Change the server name if you use a different SQL Server instance.

### 3. Apply migrations

Open the Package Manager Console and run:

```powershell
Update-Database
```

### 4. Run the application

Press `Ctrl + F5`, or select the HTTPS run profile in Visual Studio.

## Planned Improvements

- Complete Edit, Details, and Delete operations
- Search and filter tasks
- Add a stored-procedure-based task summary report
- Fetch current weather from an external API
- Display the current time and weather on the dashboard

## Learning Outcomes

This project demonstrates:

- ASP.NET Core MVC request flow
- Code First development with EF Core
- EF Core migrations
- Dependency injection
- Asynchronous database operations
- Model validation and Razor Tag Helpers
- LINQ queries
- SQL Server integration

## Author

**Titiksha Jangid**

