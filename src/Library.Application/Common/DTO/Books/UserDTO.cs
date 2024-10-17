namespace Library.Application.Common.DTO.Books;
public class UserDTO
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }
}