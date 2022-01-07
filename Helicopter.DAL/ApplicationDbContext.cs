using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Helicopter.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
      
        public DbSet<Game>? Game { get; set; }
        public DbSet<GameCategory>? GameCategory { get; set; }

    }
}
