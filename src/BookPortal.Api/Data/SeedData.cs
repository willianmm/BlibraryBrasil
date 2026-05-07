using BookPortal.Api.Models;

namespace BookPortal.Api.Data;

public static class SeedData
{
    public static IReadOnlyList<Book> Books { get; } =
    [
        new Book
        {
            Id = Guid.Parse("22c217af-b85f-4e03-a4f9-ffbe432a7137"),
            Title = "Memorias de uma Biblioteca",
            Author = "Coletivo Educacao Aberta",
            Description = "Ensaios curtos sobre leitura, escola e formacao de leitores.",
            Category = "Educacao",
            Format = "E-book",
            Language = "Portugues",
            AgeRange = "14+",
            CoverColor = "#174f7a",
            CoverAccent = "#f7c948",
            Tags = ["sala-de-aula", "educacao", "ensaio"],
            CopiesAvailable = 8,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-2)
        },
        new Book
        {
            Id = Guid.Parse("21e577bf-b81c-42f6-8d7a-19b908d4d503"),
            Title = "Dom Casmurro",
            Author = "Machado de Assis",
            Description = "Romance brasileiro sobre memoria, ciume e narracao em primeira pessoa.",
            Category = "Literatura Brasileira",
            Format = "E-book",
            Language = "Portugues",
            AgeRange = "14+",
            CoverColor = "#5b2333",
            CoverAccent = "#f3dfbf",
            Tags = ["classico", "romance", "vestibular"],
            CopiesAvailable = 12,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-12)
        },
        new Book
        {
            Id = Guid.Parse("afe52e80-7c16-4adf-990a-6f356391dd2d"),
            Title = "O Alienista",
            Author = "Machado de Assis",
            Description = "Novela satirica sobre ciencia, poder e normalidade.",
            Category = "Literatura Brasileira",
            Format = "E-book",
            Language = "Portugues",
            AgeRange = "12+",
            CoverColor = "#31473a",
            CoverAccent = "#f2a65a",
            Tags = ["classico", "conto", "sala-de-aula"],
            CopiesAvailable = 6,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-7)
        },
        new Book
        {
            Id = Guid.Parse("3e0c3dd8-0f43-4f31-bd9e-f5ca0b8128f1"),
            Title = "Iracema",
            Author = "Jose de Alencar",
            Description = "Romance indianista que integra o repertorio classico brasileiro.",
            Category = "Literatura Brasileira",
            Format = "E-book",
            Language = "Portugues",
            AgeRange = "13+",
            CoverColor = "#2e6f40",
            CoverAccent = "#f4d35e",
            Tags = ["classico", "romance", "sala-de-aula"],
            CopiesAvailable = 4,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-18)
        },
        new Book
        {
            Id = Guid.Parse("f246b373-0d0d-4750-b79c-08b3cef34875"),
            Title = "Ciencias em Campo",
            Author = "Lia Nascimento",
            Description = "Projetos investigativos para conectar ciencias, territorio e cotidiano.",
            Category = "Ciencias",
            Format = "PDF",
            Language = "Portugues",
            AgeRange = "10+",
            CoverColor = "#096b72",
            CoverAccent = "#b8f2e6",
            Tags = ["sala-de-aula", "ciencias", "projetos"],
            CopiesAvailable = 10,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-3)
        },
        new Book
        {
            Id = Guid.Parse("bc0ef397-d612-435e-83bb-e6678f85a258"),
            Title = "Matematica em Rotas",
            Author = "Rafael Souto",
            Description = "Atividades de resolucao de problemas com mapas, dados e jogos.",
            Category = "Matematica",
            Format = "PDF",
            Language = "Portugues",
            AgeRange = "11+",
            CoverColor = "#433878",
            CoverAccent = "#ffe66d",
            Tags = ["sala-de-aula", "matematica", "atividades"],
            CopiesAvailable = 7,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-5)
        },
        new Book
        {
            Id = Guid.Parse("ec718f39-3081-4769-86dd-68fd07d8ac41"),
            Title = "A Moreninha",
            Author = "Joaquim Manuel de Macedo",
            Description = "Romance urbano do seculo XIX e marco do romantismo brasileiro.",
            Category = "Literatura Brasileira",
            Format = "E-book",
            Language = "Portugues",
            AgeRange = "13+",
            CoverColor = "#6d597a",
            CoverAccent = "#eaac8b",
            Tags = ["classico", "romance"],
            CopiesAvailable = 5,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-21)
        },
        new Book
        {
            Id = Guid.Parse("83ab1b82-62b8-47a3-9297-25f9ba2f7dd1"),
            Title = "Historias do Brasil em Fontes",
            Author = "Marina Valente",
            Description = "Documento, imagem e narrativa para investigar periodos da historia brasileira.",
            Category = "Historia",
            Format = "PDF",
            Language = "Portugues",
            AgeRange = "12+",
            CoverColor = "#7b3f00",
            CoverAccent = "#ffd166",
            Tags = ["historia", "sala-de-aula", "fontes"],
            CopiesAvailable = 0,
            AddedAt = DateTimeOffset.UtcNow.AddDays(-1)
        }
    ];
}

