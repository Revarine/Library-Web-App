namespace Library.Contracts.Authors;

public record CreateAuthorRequest(DateTime dateOfBirth, string country, string name, string surname);