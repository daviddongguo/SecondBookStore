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

        public EFDbContext Context = new EFDbContext();

        public IEnumerable<Product> ProductsList
        {
            get { return this.Context.ProductsList; }
        }

        public int Add(Product product)
        {
            var dbProduct = this.Context.ProductsList.Add(product);
            this.Context.SaveChanges();

            return dbProduct.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
