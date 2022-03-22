using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BankSystem.Entities;

namespace BankSystem
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public AppContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
