using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>()
            .HasMany(b => b.Books)
            .WithOne(a => a.Author)
            .HasForeignKey(b => b.AuthorId);
        modelBuilder.Entity<Publisher>()
            .HasMany(b => b.Books)
            .WithOne(p => p.Publisher)
            .HasForeignKey(b => b.PublisherId);
        
        //Configure
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Title)
            .IsUnique();
        modelBuilder.Entity<Author>()
            .HasIndex(a => a.Name)
            .IsUnique();
        modelBuilder.Entity<Publisher>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}