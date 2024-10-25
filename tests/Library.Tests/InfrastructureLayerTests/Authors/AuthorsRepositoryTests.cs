using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Library.Infrastructure.Repositories.Authors.Persistence;

namespace Library.Tests.InfrastructureLayerTests.Authors;

public class AuthorRepositoryTests
{
    private readonly LibraryDbContext _context;
    private readonly AuthorRepository _authorRepository;

    public AuthorRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new LibraryDbContext(options);
        _authorRepository = new AuthorRepository(_context);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAuthors()
    {
        // Arrange
        var authors = new List<Author>
        {
            new(Guid.NewGuid(), DateTime.Now, "Belarus", "John", "Doe"),
            new(Guid.NewGuid(), DateTime.Now, "Belarus", "Jane", "Doe")
        };
        await _context.Authors.AddRangeAsync(authors);
        await _context.SaveChangesAsync();

        // Act
        var result = await _authorRepository.GetElementsAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(authors);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectAuthor()
    {
        // Arrange
        var author = new Author(Guid.NewGuid(), DateTime.Now, "Belarus", "John", "Doe");
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();

        // Act
        var result = await _authorRepository.GetElementByIdAsync(author.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(author);
    }

    [Fact]
    public async Task AddAsync_ShouldAddNewAuthor()
    {
        // Arrange
        var author = new Author(Guid.NewGuid(), DateTime.Now, "Belarus", "John", "Doe");

        // Act
        await _authorRepository.CreateAsync(author);
        await _context.SaveChangesAsync();

        // Assert
        var addedAuthor = await _context.Authors.FindAsync(author.Id);
        addedAuthor.Should().NotBeNull();
        addedAuthor.Should().BeEquivalentTo(author);
    }


}