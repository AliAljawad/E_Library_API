using E_Library_API.Data;
using E_Library_API.Model;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace E_Library_API.Controllers;

public static class GenresController
{
    public static void MapGenreEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Genre").WithTags(nameof(Genre));

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Genres.ToListAsync();
        })
        .WithName("GetAllGenres")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Genre>, NotFound>> (Guid guid, AppDbContext db) =>
        {
            return await db.Genres.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Guid == guid)
                is Genre model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetGenreById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid guid, Genre genre, AppDbContext db) =>
        {
            var affected = await db.Genres
                .Where(model => model.Guid == guid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.GenreName, genre.GenreName)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateGenre")
        .WithOpenApi();

        group.MapPost("/", async (Genre genre, AppDbContext db) =>
        {
            db.Genres.Add(genre);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Genre/{genre.Guid}", genre);
        })
        .WithName("CreateGenre")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid guid, AppDbContext db) =>
        {
            var affected = await db.Genres
                .Where(model => model.Guid == guid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteGenre")
        .WithOpenApi();
    }
}
