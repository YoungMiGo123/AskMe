using AskMe.Core.Core.Data.Context;
using AskMe.Core.Core.Repositories.Interfaces;

namespace AskMe.Core.Core.Repositories.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AskMeDbContext _askMeDbContext;

        public UnitOfWork(AskMeDbContext askMeDbContext)
        {
            _askMeDbContext = askMeDbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            return _askMeDbContext.SaveChanges() > 0;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _askMeDbContext?.Dispose();
            }
        }
    }
}
