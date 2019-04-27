using David.SecondBook.OnlineStore.Domain.Abstract;
using David.SecondBook.OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.Domain.Concrete
{
    public class EFDbProductsRepository : IProductsRepository
    {

        public EFDbContext context = new EFDbContext();

        public IEnumerable<Product> ProductsList
        {
            get { return this.context.ProductsList; }
        }

        public int Add(Product product)
        {
            var dbProduct = this.context.ProductsList.Add(product);
            this.context.SaveChanges();

            return dbProduct.Id;
        }

        public Product DeleteProduct(int id)
        {
            var dbProduct = FindById(id);
            if(dbProduct != null)
            {
                this.context.ProductsList.Remove(dbProduct);
                this.context.SaveChanges();
            }

            return dbProduct;
        }

        public Product FindById(int id)
        {
            return this.context.ProductsList.FirstOrDefault( p => p.Id == id);
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.ProductsList.Add(product);
            }
            else
            {
                Product dbEntry = context.ProductsList.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();

        }

        public void Update(int id, Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
