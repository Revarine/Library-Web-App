namespace Library.Domain.Entities;

public class TakenBook
{
    public Guid BookId { get; private set; }
    public virtual Book Book { get; private set; }
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }
    public DateTime? TakeDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public TakenBook(Guid bookId, Guid userId, DateTime? takeDate, DateTime? returnDate)
    {
        BookId = bookId;
        UserId = userId;
        TakeDate = takeDate;
        ReturnDate = returnDate;
    }

    private TakenBook() { }
}