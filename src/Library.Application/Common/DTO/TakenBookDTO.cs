namespace Library.Application.Common.DTO;

public class TakenBookDTO
{
    public Guid BookId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime? TakeDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
}