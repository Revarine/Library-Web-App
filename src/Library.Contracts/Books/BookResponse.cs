namespace Library.Contracts.Books;

public record BookResponse(Guid id, string title, string description, short genreId, Guid authorId, string isbn, int amount);