namespace Library.Contracts.Books;

public record CreateBookRequest(string title, string description, int genreId, Guid authorId, string isbn, int amount);