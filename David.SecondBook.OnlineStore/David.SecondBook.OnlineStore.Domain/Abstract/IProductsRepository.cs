using David.SecondBook.OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> ProductsList { get; }
        Product FindById(int id);
        int Add(Product product);
        void Update(int id, Product Product);
        void Delete(int id);
    }
}
