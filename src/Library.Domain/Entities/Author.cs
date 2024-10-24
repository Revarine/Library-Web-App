namespace Library.Domain.Entities;

public class Author
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Country { get; private set; }
    public virtual ICollection<Book> Books { get; private set; }

    public Author(Guid? id, DateTime dateOfBirth, string country, string name, string surname)
    {
        Id = id ?? Guid.NewGuid();
        DateOfBirth = dateOfBirth;
        Country = country;
        Name = name;
        Surname = surname;
    }

    private Author() { }
}