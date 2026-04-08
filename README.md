# EventHub

EventHub is a REST API for publishing and booking events, built with Domain-Driven Design principles.

Users can register as either a **User** (browse and book events) or an **Organizer** (create, manage, and publish events with photos).

## Features

- JWT authentication with role-based authorization
- Full event lifecycle: create, update, cancel, upload photos
- Booking system with automatic waitlist promotion on cancellation
- Photo upload support for events

## Tech Stack

C#, PostgreSQL, Entity Framework Core, JWT Bearer tokens

## Project Structure

```
EventHub/
├── Domain/            # Entities, Enums (Event, Booking, User)
├── Application/       # DTOs, Interfaces, Dependency registration
├── Infrastructure/    # EF Core, Repositories, Services, Auth
├── Presentation/      # Controllers (Events, Bookings, Auth)
└── Migrations/
```



## License

This project is for educational purposes.
