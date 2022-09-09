namespace AskMe.Core.Core.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }
}
