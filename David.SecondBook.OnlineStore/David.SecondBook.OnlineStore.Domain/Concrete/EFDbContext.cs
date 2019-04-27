namespace David.SecondBook.OnlineStore.Domain.Entities
{
    using David.SecondBook.OnlineStore.Domain.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {
        }

        public DbSet<Product> ProductsList { get; set; }
        public DbSet<LoginUser> LoginUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("secondbookstore");
        }

    }
}
