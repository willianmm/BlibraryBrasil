namespace BookPortal.Api.Data;

public sealed class DatabaseOptions
{
    public bool UseSqlite { get; init; }
    public bool ApplyMigrationsOnStartup { get; init; }
    public bool SeedOnStartup { get; init; } = true;
}

