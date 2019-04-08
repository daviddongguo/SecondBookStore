using David.SecondBook.OnlineStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.WebApi.Data
{
    public class ProductsDbContext : DbContext
    {

        public ProductsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Prodocts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

            });


        }
    }
}
