using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Entities.Base;
using NLayerApp.Core.Repositories.Generic;
using NLayerApp.DAL.Data;

namespace NLayerApp.DAL.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbSet<TEntity> _db;
        private readonly AppDbContext _context;


        public EfRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void DeleteAsync(int id)
        {
            var entity = _db.FirstOrDefault(x => x.Id == id);
            if (entity is not null)
            {
                _db.Remove(entity);
            }
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            var entities = _db.AsNoTracking().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _db.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public void UpdateAsync(TEntity entity)
        {
            _db.Update(entity);
        }
    }
}
