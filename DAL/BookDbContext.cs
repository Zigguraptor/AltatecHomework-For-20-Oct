#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using AltatecHomework_For_20_Oct.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltatecHomework_For_20_Oct.DAL;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<BookEntity> Books { get; set; } = null!;

    public void Init()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        Books.AddRange(TestBookInfos());
        SaveChanges();
    }

    private static IEnumerable<BookEntity> TestBookInfos()
    {
        yield return new BookEntity
        {
            Guid = Guid.NewGuid(),
            Title = "Война и мир. Том I",
            Author = "Л. Н. Толстой.",
            PriceRub = 165.99m
        };
        yield return new BookEntity
        {
            Guid = Guid.NewGuid(),
            Title = "Война и мир. Том II",
            Author = "Л. Н. Толстой.",
            PriceRub = 489.99m
        };
        yield return new BookEntity
        {
            Guid = Guid.NewGuid(),
            Title = "Война и мир. Том III",
            Author = "Л. Н. Толстой.",
            PriceRub = 356.99m
        };
        yield return new BookEntity
        {
            Guid = Guid.NewGuid(),
            Title = "Война и мир. Том IV",
            Author = "Л. Н. Толстой.",
            PriceRub = 234.99m
        };
    }
}
