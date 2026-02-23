# Test Plan (MVP)

This is a lightweight manual test plan for the Service Desk Lite MVP.

## Environment
- App: ASP.NET Core MVC
- DB: SQL Server (Docker)
- ORM: Entity Framework Core migrations

## Smoke Tests
1. App boots without errors
2. Home dashboard loads and shows ticket counts
3. Tickets page loads

## Ticket Workflow Tests
### Create Ticket
- Create ticket with Title, Description, Assigned User, and Status
- Verify ticket appears in Tickets list
- Verify ticket persists after app restart

### Validation
- Attempt to create ticket without Title
- Attempt to create ticket without Description
- Verify validation messages display and ticket is not created

### Details View
- Open ticket details
- Verify assigned technician, status badge, and timestamps display

### Edit Ticket
- Edit Title and Description
- Reassign technician
- Change status
- Verify changes persist

### Status Buttons
- Use Details page buttons to set Open/InProgress/Closed
- Verify badge updates and persists

## Comments
- Add a comment to a ticket
- Verify comment appears in list
- Add multiple comments and verify ordering is newest-first

## Basic Data Integrity
- Verify each Ticket references a valid User (FK relationship)
- Verify each Comment references a valid Ticket (FK relationship)