namespace Library.Application.Common.DTO.Books;

public class BookDTO
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int GenreId { get; private set; }
    public Guid AuthorId { get; private set; }
    public string ISBN { get; private set; }
    public int Amount { get; private set; }
}