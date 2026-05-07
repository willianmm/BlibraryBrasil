namespace BookPortal.Api.Dtos;

public sealed record CatalogQuery(string? Search, string? Category, string? Format, bool? Available);

