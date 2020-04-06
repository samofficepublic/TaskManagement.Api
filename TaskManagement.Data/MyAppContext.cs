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
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new AccessConfig());
            modelBuilder.ApplyConfiguration(new UserAccessConfig());
            
        }

        #region dbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; }
        #endregion
    }
}