# Service Desk Lite

ASP.NET Core MVC ticket management system demonstrating C#, Entity Framework Core, SQL Server, and IIS deployment.

## Why this project
This project is built as an interview-ready MVP to demonstrate:
- ASP.NET Core MVC fundamentals
- Entity Framework Core with SQL Server
- Relational schema design and normalization
- Git workflow and documentation discipline
- IIS hosting readiness (publish + deploy)

## Tech Stack
- **Backend:** ASP.NET Core MVC (C#)
- **Data:** Entity Framework Core, SQL Server
- **Hosting:** IIS (local), cloud-ready configuration
- **Tooling:** Git, GitHub

## Planned MVP Features
- Ticket CRUD: Create, List, Details, Edit, Close
- Technician assignment (simple)
- Status workflow: Open → In Progress → Closed
- Database-backed persistence with migrations
- Basic validation and error handling

## Getting Started

### 1) Start SQL Server (Docker)
```bash
docker rm -f sdl-sqlserver 2>/dev/null || true

docker run \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=Str0ngPassw0rd" \
  -p 1433:1433 \
  --name sdl-sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest


## Add a “Demo Script” section
```md
## Interview Demo Script (2–3 minutes)

1. Open Dashboard
   - Show counts for Open / In Progress / Closed
   - Explain MVC + EF Core + SQL Server (Docker)

2. Go to Tickets
   - Create a new ticket (assigned user + status)
   - Show it appears in list with status badge

3. Open Ticket Details
   - Change status using workflow buttons
   - Add a comment to simulate support updates

4. Edit Ticket
   - Update assignment or description
   - Emphasize relational model (Users → Tickets → Comments)

## Screenshots
Add screenshots here:
- Dashboard
- Tickets list
- Ticket details with comments

## Repository Structure (coming soon)
- `/src` Application source
- `/docs` Architecture notes and diagrams