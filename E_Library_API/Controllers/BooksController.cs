using E_Library_API.Data;
using E_Library_API.Model;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace E_Library_API.Controllers;

public static class BooksController
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Book").WithTags(nameof(Book));

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Books.ToListAsync();
        })
        .WithName("GetAllBooks")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Book>, NotFound>> (Guid bookGuid, AppDbContext db) =>
        {
            return await db.Books.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Guid == bookGuid)
                is Book model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetBookById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid bookGuid, Book book, AppDbContext db) =>
        {
            var affected = await db.Books
                .Where(model => model.Guid == bookGuid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Title, book.Title)
                    .SetProperty(m => m.Author, book.Author)
                    .SetProperty(m => m.AvailabilityStatus, book.AvailabilityStatus)
                    .SetProperty(m => m.PublishDate, book.PublishDate)
                    .SetProperty(m => m.Description, book.Description)
                    .SetProperty(m => m.Quantity, book.Quantity)
                    .SetProperty(m => m.AvailableQuantity, book.AvailableQuantity)
                    .SetProperty(m => m.BorrowedQuantity, book.BorrowedQuantity)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateBook")
        .WithOpenApi();

        group.MapPost("/", async (Book book, AppDbContext db) =>
        {
            if (book.Genre != null)
            {
                var bookGenre = await db.Genres.FirstOrDefaultAsync(g => g.Guid == book.Genre.Guid);
                book.Genre = bookGenre;
            }
            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Book/{book.Guid}", book);
        })
        .WithName("CreateBook")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid bookGuid, AppDbContext db) =>
        {
            var affected = await db.Books
                .Where(model => model.Guid == bookGuid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteBook")
        .WithOpenApi();
    }
}
