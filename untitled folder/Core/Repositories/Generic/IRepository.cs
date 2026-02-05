using NLayerApp.Core.Entities.Base;

namespace NLayerApp.Core.Repositories.Generic
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        void UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
