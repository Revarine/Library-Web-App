namespace Library.Domain.Entities;

public class Genre
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<Book> Books { get; private set; }

    public Genre(int? id, string name)
    {
        Name = name;
    }

    private Genre() { }
}
