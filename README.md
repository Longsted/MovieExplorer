# Movie Explorer

Movie Explorer is an ASP.NET Core MVC application that uses The Movie Database (TMDB) API to help users discover movies by genre, search for titles, and manage a personal wishlist.

The project is built as a portfolio application with a focus on clean architecture, maintainability, and separation of concerns.

---

## Features

- Browse movies by genre
- Search movies
- Movie details
- Wishlist
- Load More pagination
- Search pagination
- Responsive Bootstrap UI
- TMDB API integration

---

## Technologies

- ASP.NET Core MVC
- C#
- TMDB API
- Bootstrap
- JavaScript
- Dependency Injection
- Clean Architecture

---

## Project Structure

The project follows Clean Architecture principles.

```text
MovieExplorer.Web
        │
        ▼
MovieExplorer.Application
        │
        ▼
MovieExplorer.Domain
        ▲
        │
MovieExplorer.Infrastructure
```

Responsibilities:

- **Web** – MVC controllers and views
- **Application** – Services and use cases
- **Domain** – Business models and repository contracts
- **Infrastructure** – TMDB API, repositories and external services

---

## Roadmap

### Planned

- [ ] Movie reviews
- [ ] Similar movies
- [ ] Streaming providers
- [ ] Unit tests
- [ ] Deployment

### Nice to Have

- [ ] Trailer integration
- [ ] Caching
- [ ] Dark mode


## Learning Goals

This project is built to practice:

- Clean Architecture
- Dependency Injection
- Repository Pattern
- REST API integration
- ASP.NET Core MVC
- Software design principles

## architecture decisions 
I used clean architecture because i'd never tried it and i wanted to gain experience

I used the Repository Pattern because I wanted better separation of concerns. 
I didn't want data access and business logic living in the same class.

Why TMDB?
I stumbled upon TMDB while looking for a movie API
and thought it would be a fun way to practice working with external APIs.


---

## Configuration

The application uses ASP.NET Core User Secrets for storing the TMDB API key.

Initialize user secrets:

```bash
dotnet user-secrets init --project MovieExplorer.Web
```

Add your TMDB API key:

```bash
dotnet user-secrets set "Tmdb:ApiKey" "YOUR_API_KEY" --project MovieExplorer.Web
```

---

## Running the application

```bash
dotnet run --project MovieExplorer.Web
```