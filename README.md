# 💈 BarberControl

Management system for barbershops, focused on:

- control of **clients**
- **barbers**
- **services**
- **appointments**
- (future) visibility of **profitability** and business metrics

Project developed as a practical study of:

- .NET 10
- ASP.NET Core Web API
- Blazor
- Entity Framework Core 10
- SQL Server
- Layered architecture (Domain / Infrastructure / API / UI)

---

## 🔍 Overview

Many barbershops still use:

- paper schedules
- generic calendar apps
- random notes on WhatsApp

This makes it difficult to:

- see all barbers’ schedules in a single place
- avoid time conflicts
- keep a history of appointments
- understand peak hours, best-selling services, profitability, etc.

**BarberControl** was created to organize all of this in a simple, focused, and expandable way.

---

## 🎯 System Goals

- Centralize **client, barber, and service registration**
- Allow **appointment scheduling** in a simple and visual way
- Prevent **schedule conflicts** for the same barber
- Store **appointment history** per client
- Serve as a study base for:
  - layered architecture
  - ASP.NET Core Web API
  - EF Core 10 (migrations, DbContext, etc.)
  - Blazor as front-end
  - version control best practices (Git/GitHub)

---

## 👤 Target Audience

- **Barbershop owners** who want to:
  - organize their schedule
  - manage clients and barbers
  - have a basic view of performance/profitability

- **Barbers** who want to:
  - view their daily schedule in a simple way

- **Developers** (like Kelvin in the present and future 😄) who want to:
  - study .NET 10, Blazor, Web API and EF Core
  - practice layered architecture and good practices

---

## 🚀 Features (MVP)

### 1. Client Management

- Create, list, edit, and deactivate clients
- Main fields:
  - Name
  - Phone
  - Email (optional)
  - Registration Date

### 2. Barber Management

- Create, list, edit, and deactivate barbers
- Main fields:
  - Name
  - Specialties (free text)
  - Active/Inactive

### 3. Service Management

- Create, list, edit, and deactivate services
- Main fields:
  - Name
  - Description
  - Duration in minutes
  - Price

### 4. Scheduling

- Create appointments linking:
  - Client
  - Barber
  - Service
  - Date/Time
- Prevent scheduling conflicts for the **same barber** at the **same time**
- List appointments:
  - by day
  - by barber
  - by client

### 5. Basic Infrastructure

- **SQL Server** database with:
  - `dbBarberControl` as the main database
  - migrations via **EF Core 10**
- API in **ASP.NET Core** to manage:
  - Clients
  - Barbers
  - Services
  - Appointments
- Front-end in **Blazor** consuming the API

---

## 🧭 Future Features (Roadmap)

- Authentication and authorization:
  - owner login
  - barber login
- Dashboard with metrics:
  - peak hours
  - most requested services
  - barber with the most appointments
  - profitability per barber
- Integration with WhatsApp / messaging API:
  - appointment reminders
- AI-based recommendations:
  - best time slots based on history
  - suggestion of complementary services
- Simple cash register system:
  - record of paid appointments
  - daily/monthly estimated revenue report

---

## 🏗️ Architecture

The project follows a layered architecture:

```text
BarberControl/
  src/
    Barbearia.Domain/        -> Business rules, domain entities
    Barbearia.Infrastructure/-> Data access (EF Core, DbContext, Migrations)
    Barbearia.Api/           -> ASP.NET Core Web API
    Barbearia.Blazor/        -> Blazor front-end
  tests/
    Barbearia.Tests/         -> Automated tests (when implemented)