using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Models;
using TaskFlow.DataAccess.Configurations;
using TaskFlow.DataAccess.Entities;

namespace TaskFlow.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Tasks = Set<TaskEntity>();
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder configurationBuilder)
        {
            configurationBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
