using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookPortal.Api.Data;

public sealed class DatabaseInitializer
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DatabaseOptions _options;

    public DatabaseInitializer(IServiceProvider serviceProvider, IOptions<DatabaseOptions> options)
    {
        _serviceProvider = serviceProvider;
        _options = options.Value;
    }

    public async Task InitializeAsync()
    {
        if (!_options.UseSqlite)
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

        if (_options.ApplyMigrationsOnStartup)
        {
            await db.Database.MigrateAsync();
        }

        if (_options.SeedOnStartup && !await db.Books.AnyAsync())
        {
            db.Books.AddRange(SeedData.Books.Select(BookEntity.FromModel));
            await db.SaveChangesAsync();
        }
    }
}

