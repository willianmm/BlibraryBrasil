namespace BookPortal.Api.Dtos;

public sealed record BorrowRequest(Guid BookId, string UserDocument, string UserName);

