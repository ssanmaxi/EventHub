# EventHub

EventHub is a REST API for publishing and booking events, built with Domain-Driven Design principles.

Users can register as either a **User** (browse and book events) or an **Organizer** (create, manage, and publish events with photos).

Built with Clean Architecture: Domain layer has entities, Application layer has DTOs & service interfaces, Infrastructure layer has EF Core and interface implementations, and Presentation is the API layer.

## Features

- JWT authentication with role-based authorization
- Full event lifecycle: create, update, cancel, upload photos
- Photo upload support for events
- Automatic waitlist promotion upon cancellation

## Tech Stack

C#, PostgreSQL, Entity Framework Core, JWT, BCrypt, FluentValidation


## Project Structure

```
EventHub/
├── Domain/            # Entities, Enums (Event, Booking, User)
├── Application/       # DTOs, Interfaces, Dependency registration
├── Infrastructure/    # EF Core, Repositories, Services, Auth
├── Presentation/      # Controllers (Events, Bookings, Auth)
└── Migrations/
```
