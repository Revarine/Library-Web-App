namespace Library.Domain.Entities;

public class Genre
{
    public short Id { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<Book> Books { get; private set; }

    public Genre(short id, string name)
    {
        Id = id;
        Name = name;
    }

    private Genre() { }
}