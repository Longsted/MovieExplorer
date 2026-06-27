using MovieExplorer.Application.Services;
using MovieExplorer.Infrastructure;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MovieExplorer.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<TmdbOptions>(builder.Configuration.GetSection("Tmdb"));
builder.Services.AddHttpClient();


//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IMovieRepository, TmdbMovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IWishlistRepository, Wishlistrepository>();



builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<WishlistService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();