using BookPortal.Api.Models;

namespace BookPortal.Api.Dtos;

public sealed record BookResponse(
    Guid Id,
    string Title,
    string Author,
    string Description,
    string Category,
    string Format,
    string Language,
    string AgeRange,
    string CoverColor,
    string CoverAccent,
    IReadOnlyList<string> Tags,
    int CopiesAvailable,
    bool IsAvailable,
    DateTimeOffset AddedAt)
{
    public static BookResponse FromModel(Book book) =>
        new(
            book.Id,
            book.Title,
            book.Author,
            book.Description,
            book.Category,
            book.Format,
            book.Language,
            book.AgeRange,
            book.CoverColor,
            book.CoverAccent,
            book.Tags,
            book.CopiesAvailable,
            book.CopiesAvailable > 0,
            book.AddedAt);
}

