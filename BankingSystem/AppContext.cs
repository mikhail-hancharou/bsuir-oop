using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Entities;

namespace BankingSystem
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public AppContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=DBase.db");
        }
    }
}