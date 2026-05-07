namespace BookPortal.Api.Models;

public sealed class Shelf
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required IReadOnlyList<Book> Books { get; init; }
}

