using BookPortal.Api.Models;

namespace BookPortal.Api.Dtos;

public sealed record LoanResponse(
    Guid Id,
    Guid BookId,
    string BookTitle,
    string UserDocument,
    DateTimeOffset BorrowedAt,
    DateTimeOffset DueAt,
    DateTimeOffset? ReturnedAt)
{
    public static LoanResponse FromModel(Loan loan) =>
        new(
            loan.Id,
            loan.BookId,
            loan.BookTitle,
            loan.UserDocument,
            loan.BorrowedAt,
            loan.DueAt,
            loan.ReturnedAt);
}

