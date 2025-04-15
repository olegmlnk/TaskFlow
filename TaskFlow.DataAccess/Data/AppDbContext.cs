using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Models;
using TaskFlow.DataAccess.Configurations;
using TaskFlow.DataAccess.Entities;

namespace TaskFlow.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<UserEntity, IdentityRole<long>, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Tasks = Set<TaskEntity>();
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder configurationBuilder)
        {
            configurationBuilder.ApplyConfiguration(new TaskConfiguration());
            configurationBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
