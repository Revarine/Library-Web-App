namespace Library.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }
    public virtual ICollection<TakenBook> TakenBooks { get; private set; }

    public User(Guid? id, string username, string email, string password, bool isAdmin)
    {
        Id = id ?? Guid.NewGuid();
        Username = username;
        Email = email;
        Password = password;
        IsAdmin = isAdmin;
    }

    private User() { }
}