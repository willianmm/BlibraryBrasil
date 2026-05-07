using BookPortal.Api.Models;

namespace BookPortal.Api.Services;

public sealed class BorrowResult
{
    private BorrowResult(bool isSuccess, Loan? loan, string? error)
    {
        IsSuccess = isSuccess;
        Loan = loan;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Loan? Loan { get; }
    public string? Error { get; }

    public static BorrowResult Success(Loan loan) => new(true, loan, null);

    public static BorrowResult Failure(string error) => new(false, null, error);
}

