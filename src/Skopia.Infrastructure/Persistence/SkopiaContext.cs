using Skopia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Persistence
{
    public class SkopiaContext : DbContext
    {
        public SkopiaContext(DbContextOptions<SkopiaContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<TaskItem> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskItem>().Property(t => t.Title).IsRequired().HasMaxLength(200);
        }
    }


}
