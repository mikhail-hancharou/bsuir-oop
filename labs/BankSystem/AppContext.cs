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
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Operator> Operators => Set<Operator>();
        public DbSet<Manager> Managers => Set<Manager>();
        public DbSet<Outsider> Outsiders => Set<Outsider>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Bank> Banks => Set<Bank>();
       // public DbSet<Bill> Bills => Set<Bill>();
        public AppContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(new Bank { Id = 1, BID = "11111", TotalMoney = 0});
        }
    }
}
