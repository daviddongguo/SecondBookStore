namespace David.SecondBook.OnlineStore.Domain.Entities
{
    using David.SecondBook.OnlineStore.Domain.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class XMLProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> ProductsList => throw new NotImplementedException();
    }
}
