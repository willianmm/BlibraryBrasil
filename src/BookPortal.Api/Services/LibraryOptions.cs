namespace BookPortal.Api.Services;

public sealed class LibraryOptions
{
    public int MaxMonthlyLoans { get; init; } = 2;
    public int LoanDays { get; init; } = 14;
}

