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
        int Add(Product product);
    }
}
