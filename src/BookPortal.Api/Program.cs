using BookPortal.Api.Data;
using BookPortal.Api.Dtos;
using BookPortal.Api.Repositories;
using BookPortal.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<LibraryOptions>(builder.Configuration.GetSection("Library"));
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));
builder.Services.AddScoped<BorrowingService>();
builder.Services.AddSingleton<DatabaseInitializer>();

if (builder.Configuration.GetValue<bool>("Database:UseSqlite"))
{
    builder.Services.AddDbContext<LibraryDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("Library")));
    builder.Services.AddScoped<ILibraryRepository, SqliteLibraryRepository>();
}
else
{
    builder.Services.AddSingleton<ILibraryRepository, InMemoryLibraryRepository>();
}

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

await app.Services.GetRequiredService<DatabaseInitializer>().InitializeAsync();

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

var api = app.MapGroup("/api");

api.MapGet("/health", () => Results.Ok(new { status = "ok", service = "digital-library" }));

api.MapGet("/catalog", async (
    ILibraryRepository repository,
    string? q,
    string? category,
    string? format,
    bool? available) =>
{
    var books = await repository.SearchAsync(new CatalogQuery(q, category, format, available));
    return Results.Ok(books.Select(BookResponse.FromModel));
});

api.MapGet("/catalog/{id:guid}", async Task<IResult> (Guid id, ILibraryRepository repository) =>
{
    var book = await repository.GetByIdAsync(id);
    if (book is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(BookResponse.FromModel(book));
});

api.MapGet("/categories", async (ILibraryRepository repository) =>
{
    var categories = await repository.GetCategoriesAsync();
    return Results.Ok(categories);
});

api.MapGet("/shelves", async (ILibraryRepository repository) =>
{
    var shelves = await repository.GetShelvesAsync();
    return Results.Ok(shelves.Select(ShelfResponse.FromModel));
});

api.MapPost("/loans", async Task<IResult> (
    BorrowRequest request,
    BorrowingService borrowingService) =>
{
    var result = await borrowingService.BorrowAsync(request);
    if (!result.IsSuccess)
    {
        return Results.BadRequest(new { error = result.Error });
    }

    return Results.Created($"/api/users/{request.UserDocument}/loans", LoanResponse.FromModel(result.Loan!));
});

api.MapGet("/users/{document}/loans", async (string document, ILibraryRepository repository) =>
{
    var loans = await repository.GetLoansByUserAsync(document);
    return Results.Ok(loans.Select(LoanResponse.FromModel));
});

app.MapFallbackToFile("index.html");

app.Run();
