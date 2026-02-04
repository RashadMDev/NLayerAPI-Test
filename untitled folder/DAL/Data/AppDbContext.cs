using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Entities;

namespace NLayerApp.DAL.Data
{
      public class AppDbContext : DbContext
      {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Category> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);
                  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
      }
}
