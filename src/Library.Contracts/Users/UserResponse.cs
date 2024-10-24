namespace Library.Contracts.Users;

public record UserResponse(Guid id, string email, string pwdhash);