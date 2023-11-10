using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.UnitOfWork;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;

namespace CleanArch.Infra.Data.UnitOfWork
{
    public class UoW : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<Type, object> _repositories;
        private bool disposed = false;

        public UoW(ApplicationDbContext context)
            => this._context = context;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            if (this._repositories.ContainsKey(typeof(TEntity)))
                return (IRepository<TEntity>)this._repositories[typeof(TEntity)];

            var repository = new Repository<TEntity>(this._context);
            this._repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task BeginTransaction() 
            => await this._context.Database.BeginTransactionAsync();

        public async Task Commit()
            => await this._context.SaveChangesAsync();

        public async Task Rollback()
            => await this._context.Database.RollbackTransactionAsync();

        public async Task Dispose()
            => await Dispose(true);

        protected virtual async Task Dispose(bool disposing)
        {
            if (!this.disposed)
                if(disposing)
                    await this._context.DisposeAsync();

            this.disposed = true;
        }
    }
}
