namespace MercedesURLShortener.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
