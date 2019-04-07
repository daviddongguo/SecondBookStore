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
        private List<Product> _productsList = new List<Product>
                {
                    new Product { Name = "Mock Football", Price = 25 },
                    new Product { Name = "Mock Surf board", Price = 179 },
                    new Product { Name = "Mock Running shoes", Price = 95 }
                };

        public IEnumerable<Product> ProductsList
        {
            get
            {
                return this._productsList;
            }
        }

        public int Add(Product product)
        {
            this._productsList.Add(product);
            return product.Id;
        }

        public void Delete(int id)
        {
            Product product = FindById(id);
            _productsList.Remove(product);
        }

        public Product FindById(int id)
        {
            return this._productsList.FirstOrDefault( s => s.Id == id);
        }

        public void Update(int id, Product product)
        {
            Product dbProduct = FindById(id);
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Description = product.Description;
            dbProduct.Category = product.Category;
        }
    }
}
