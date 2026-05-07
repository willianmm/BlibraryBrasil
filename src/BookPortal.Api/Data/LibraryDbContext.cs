using Microsoft.EntityFrameworkCore;

namespace BookPortal.Api.Data;

public sealed class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<BookEntity> Books => Set<BookEntity>();
    public DbSet<LoanEntity> Loans => Set<LoanEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>(entity =>
        {
            entity.ToTable("Books");
            entity.HasKey(book => book.Id);
            entity.Property(book => book.Title).HasMaxLength(240).IsRequired();
            entity.Property(book => book.Author).HasMaxLength(180).IsRequired();
            entity.Property(book => book.Category).HasMaxLength(120).IsRequired();
            entity.Property(book => book.Format).HasMaxLength(80).IsRequired();
            entity.Property(book => book.Language).HasMaxLength(80).IsRequired();
            entity.Property(book => book.TagsJson).HasColumnType("TEXT").IsRequired();
            entity.HasIndex(book => book.Category);
            entity.HasIndex(book => book.Title);
        });

        modelBuilder.Entity<LoanEntity>(entity =>
        {
            entity.ToTable("Loans");
            entity.HasKey(loan => loan.Id);
            entity.Property(loan => loan.UserDocument).HasMaxLength(64).IsRequired();
            entity.Property(loan => loan.BookTitle).HasMaxLength(240).IsRequired();
            entity.HasIndex(loan => loan.UserDocument);
            entity.HasOne<BookEntity>()
                .WithMany()
                .HasForeignKey(loan => loan.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

