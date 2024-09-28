using System.Reflection;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Common.Persistence;

public class LibraryDbContext : DbContext, IUnitOfWork
{
    public DbSet<Book> Books { get; set; } = null!;

    public LibraryDbContext(DbContextOptions options) : base(options)
    {

    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}