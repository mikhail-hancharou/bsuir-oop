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
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Credit> Credits => Set<Credit>();
        public DbSet<Installement> Installements => Set<Installement>();
        public AppContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(
                new Bank[]
                {
                    new Bank { Id = 1, BID = "11111", Name = "Bebra Bank", TotalMoney = 0, Clients = new List<Client>() },
                    new Bank { Id = 2, BID = "22222", Name = "Amogus Bank", TotalMoney = 0, Clients = new List<Client>() }
                });

            
            //User us2 = new User
            //{
            //    Id = 2,
            //    Name = "AAA",
            //    LastName = "BBB",
            //    Login = "LOGIN",
            //    PassportNumber = "NUMER"
            //};
            //
            //modelBuilder.Entity<User>().HasData(
            //   new User[]
            //   {
            //        us1,
            //        us2
            //   });
            //

            //        new Client {
            //            Id = 2,
            //            User = us2
            //        }
            //    });
        }
    }
}
