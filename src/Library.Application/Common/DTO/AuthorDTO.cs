namespace Library.Application.Common.DTO;

public class AuthorDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string DateOfBirth { get; private set; }
    public string Country { get; private set; }
}