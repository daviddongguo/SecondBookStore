using David.SecondBook.OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace David.SecondBook.OnlineStore.WebApp.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> ProductsList { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}