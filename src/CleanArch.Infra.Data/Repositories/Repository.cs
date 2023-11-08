using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext context)
        {
            this._dbContext = context;
            this._dbSet = this._dbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
            => await this._dbSet.ToListAsync();

        public virtual async Task<T?> GetById(long? id)
            => await this._dbSet.SingleOrDefaultAsync(p => p.Id == id);

        public virtual async Task Add(T entity)
            => await this._dbSet.AddAsync(entity);

        public virtual async Task<T> Update(T entity)
        {
            await Task.CompletedTask;
            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;

            return this._dbContext.Entry(entity).Entity;
        }

        public virtual async Task Delete(long? id)
        {
            T entityToDelete = await this._dbSet.SingleOrDefaultAsync(p => p.Id == id);
            this._dbSet.Remove(entityToDelete);
        }

        public virtual async Task Delete(T entity)
        {
            await Task.CompletedTask;
            this._dbSet.Remove(entity);
        }
    }
}
