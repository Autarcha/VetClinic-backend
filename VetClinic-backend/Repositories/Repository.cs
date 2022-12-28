using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;

namespace VetClinic_backend.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RepositoryContext repositoryContext;

        public Repository(RepositoryContext context)
        {
            repositoryContext = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await repositoryContext.AddAsync(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return repositoryContext.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            repositoryContext.Update(entity);
            return entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            repositoryContext.Remove(entity);
            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await repositoryContext.SaveChangesAsync() >= 0;
        }
    }
}
