namespace Library.Application.Common.DTO.Books;

public class TakenBookDTO
{
    public Guid BookId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime? TakeDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
}