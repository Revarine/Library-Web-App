namespace Library.Contracts.Books;

public record CreateBookRequest(string title, string description, short genreId, Guid authorId, string isbn, int amount);