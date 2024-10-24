
namespace Library.Contracts.Authors;

public record AuthorResponse(Guid id, DateTime dateOfBirth, string country, string name, string surname);