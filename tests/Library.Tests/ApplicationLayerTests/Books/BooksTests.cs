using AutoMapper;
using ErrorOr;
using FluentAssertions;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Moq;

namespace Library.Domain.UnitTests.Books;

public class BooksTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly DeleteBookCommandHandler _handler;

    public BooksTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _handler = new DeleteBookCommandHandler(_mockBookRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Handle_BookExists_ReturnsDeletedResult()
    {
        // Arrange
        var bookId = Guid.NewGuid();
        var book = new Book(bookId, "title", "description", 0, Guid.NewGuid(), "isbn", 5);
        _mockBookRepository.Setup(x => x.GetElementByIdAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        // Act
        var result = await _handler.Handle(new DeleteBookCommand(bookId), CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Result.Deleted);
    }



}