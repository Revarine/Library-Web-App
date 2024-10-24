namespace Library.Contracts.Authors;

public record UpdateAuthorRequest(Guid id, DateTime dateOfBirth, string country, string name, string surname);