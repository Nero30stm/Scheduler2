using Microsoft.EntityFrameworkCore;
using ShedulerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShedulerWebApp
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Header = "task1", Description = "nado" },
                new Task { Id = 2, Header = "task2", Description = "ochen nado" });
        }
    }
}
