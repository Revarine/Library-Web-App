namespace Library.Contracts.TakenBooks;

public record TakenBookResponse(Guid bookId, Guid userId, DateTime? takeDate, DateTime? returnDate);