namespace VetClinic_backend.Interfaces
{
    public interface IRepository<TEntity>
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<TEntity> RemoveAsync(TEntity entity);
        public Task<bool> SaveChangesAsync();
    }
}
