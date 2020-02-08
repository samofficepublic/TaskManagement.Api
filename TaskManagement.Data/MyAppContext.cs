using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.EntityConfigs;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        #region dbSets
        public DbSet<User> Users { get; set; }
        #endregion
    }
}