# GitHub Activity Viewer

[Project from roadmap.sh.](https://roadmap.sh/projects/github-user-activity)  
A C# console application that fetches and displays recent GitHub user activities in a readable format.

## Features

- Retrieves recent events for a specified GitHub username using the GitHub API.
- Supports formatting for Push and Create events.

## Project Structure

- `Clients/` – HTTP client for GitHub API.
- `DTOs/` – Data Transfer Objects for deserializing API responses.
- `Models/` – Domain models and Visitor interfaces.
- `Services/` – Business logic, event factories, and formatters.
- `Utils/` – Utility classes (e.g., JSON settings).
- `Program.cs` – Application entry point.

## Getting Started

### Build and Run

```sh
dotnet build Main/Main.csproj
dotnet run --project Main/Main.csproj
```

Enter a GitHub username when prompted to see their recent activity.

### TODO:
1. Add all github events
2. Add tests
3. Add error handling
