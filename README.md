# fullstack-exercise

Flight schedules application with an Angular frontend and .NET 8 backend.

## Project Structure

```
├── backend/
│   ├── DataProducerService/       # Background worker that seeds flight data into SQLite
│   ├── FlightsData/               # Shared EF Core DbContext and models
│   └── FlightsService/            # ASP.NET Core Web API (Swagger enabled)
└── frontend/                      # Angular 20 SPA
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18+)
- [Angular CLI](https://angular.dev/) (`npm install -g @angular/cli`)

## Reset Database

If you need to recreate the database (e.g. after a schema change), run from the repo root:

```bash
cmd /c reset-db.bat
```

## Running the Application

### 1. Start the Data Producer (seeds the database)

```bash
dotnet run --project DataProducerService.Biz
```

This creates `flights.db` and inserts a new flight every 5 seconds. Keep it running or stop it once you have enough data.

### 2. Start the Flights API

```bash
dotnet run --project FlightsService.Api
```

- API: https://localhost:61046/api/flight
- Swagger UI: https://localhost:61046/swagger

### 3. Start the Frontend

```bash
npm install
npm start
```

The Angular dev server starts at http://localhost:4200 and proxies `/api` requests to the backend.
