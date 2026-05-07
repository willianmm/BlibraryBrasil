namespace BookPortal.Api.Models;

public sealed class Loan
{
    public required Guid Id { get; init; }
    public required Guid BookId { get; init; }
    public required string BookTitle { get; init; }
    public required string UserDocument { get; init; }
    public required DateTimeOffset BorrowedAt { get; init; }
    public required DateTimeOffset DueAt { get; init; }
    public DateTimeOffset? ReturnedAt { get; init; }
}

