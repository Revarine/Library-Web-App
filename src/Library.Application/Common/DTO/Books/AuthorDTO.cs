namespace Library.Application.Common.DTO.Books;

public class AuthorDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
}