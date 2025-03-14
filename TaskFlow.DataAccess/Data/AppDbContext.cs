﻿using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Configurations;
using TaskFlow.Application.Entities;

namespace TaskFlow.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder configurationBuilder)
        {
            configurationBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
