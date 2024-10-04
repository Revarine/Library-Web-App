namespace Library.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}