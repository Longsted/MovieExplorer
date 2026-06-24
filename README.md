# MovieExplorer

MovieExplorer is an ASP.NET Core MVC application

## Technologies

* ASP.NET Core MVC
* C#
* TMDB API
* Bootstrap
* Clean Architecture

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

## Running the application

```bash
dotnet run --project MovieExplorer.Web
```
