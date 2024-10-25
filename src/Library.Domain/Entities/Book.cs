namespace Library.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int GenreId { get; private set; }
    public virtual Genre Genre { get; private set; }
    public Guid AuthorId { get; private set; }
    public virtual Author Author { get; private set; }
    public string ISBN { get; private set; }
    public int Amount { get; private set; }
    public virtual ICollection<TakenBook> TakenBooks { get; private set; }

    public Book(Guid? id, string title, string description, int genreId, Guid authorId, string isbn, int amount)
    {
        Id = id ?? Guid.NewGuid();
        Title = title;
        Description = description;
        GenreId = genreId;
        AuthorId = authorId;
        ISBN = isbn;
        Amount = amount;
    }
    private Book() { }
}