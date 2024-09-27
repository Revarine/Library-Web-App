namespace Library.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public short GenreId { get; private set; }
    public virtual Genre Genre { get; private set; }
    public Guid AuthorId { get; private set; }
    public virtual Author Author { get; private set; }
    public string ISBN { get; private set; }
    public int Amount { get; private set; }
}