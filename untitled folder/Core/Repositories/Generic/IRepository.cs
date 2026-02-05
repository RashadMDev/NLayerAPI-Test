using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Entities.Base;

namespace NLayerApp.Core.Repositories.Generic
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void DeleteAsync(int id);
        void UpdateAsync(TEntity entity);
    }
}
