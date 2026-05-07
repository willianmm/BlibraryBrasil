using BookPortal.Api.Models;

namespace BookPortal.Api.Data;

public sealed class LoanEntity
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string UserDocument { get; set; } = string.Empty;
    public DateTimeOffset BorrowedAt { get; set; }
    public DateTimeOffset DueAt { get; set; }
    public DateTimeOffset? ReturnedAt { get; set; }

    public Loan ToModel() =>
        new()
        {
            Id = Id,
            BookId = BookId,
            BookTitle = BookTitle,
            UserDocument = UserDocument,
            BorrowedAt = BorrowedAt,
            DueAt = DueAt,
            ReturnedAt = ReturnedAt
        };

    public static LoanEntity FromModel(Loan loan) =>
        new()
        {
            Id = loan.Id,
            BookId = loan.BookId,
            BookTitle = loan.BookTitle,
            UserDocument = loan.UserDocument,
            BorrowedAt = loan.BorrowedAt,
            DueAt = loan.DueAt,
            ReturnedAt = loan.ReturnedAt
        };
}

