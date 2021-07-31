using Backend_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<PersonModel> Persons { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationDB;Trusted_Connection=True;");
        }
    }
}
