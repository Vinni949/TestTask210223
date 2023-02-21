﻿using Microsoft.EntityFrameworkCore;

namespace TestTask210223.Models
{
    public class DBProduct : DbContext
    {
        public DBProduct()
        {
            Database.EnsureCreated();   // гарантируем, что БД создана
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
