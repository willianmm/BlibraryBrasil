using BookPortal.Api.Models;

namespace BookPortal.Api.Dtos;

public sealed record ShelfResponse(string Name, string Description, IReadOnlyList<BookResponse> Books)
{
    public static ShelfResponse FromModel(Shelf shelf) =>
        new(
            shelf.Name,
            shelf.Description,
            shelf.Books.Select(BookResponse.FromModel).ToList());
}

