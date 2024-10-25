namespace Library.Contracts.Books;

public record BookResponse(Guid id, string title, string description, int genreId, Guid authorId, string isbn, int amount);