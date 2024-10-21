namespace Library.Domain.Entities;

public class Author
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string DateOfBirth { get; private set; }
    public string Country { get; private set; }
    public virtual ICollection<Book> Books { get; private set; }

    public Author(Guid? id, string name, string surname)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Surname = surname;
    }

    private Author() { }
}