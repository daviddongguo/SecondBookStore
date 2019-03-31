namespace David.SecondBook.OnlineStore.Domain.Abstract
{
    using David.SecondBook.OnlineStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MockProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> ProductsList
        {
            get
            {
                return new List<Product>
                {
                    new Product { Name = "Mock Football", Price = 25 },
                    new Product { Name = "Mock Surf board", Price = 179 },
                    new Product { Name = "Mock Running shoes", Price = 95 }
                };
            }
        }
    }
}
