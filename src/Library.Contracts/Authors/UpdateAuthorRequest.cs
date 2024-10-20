namespace Library.Contracts.Authors;

public record UpdateAuthorRequest(Guid id, string name, string surname);