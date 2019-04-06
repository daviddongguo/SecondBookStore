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
    }
}
