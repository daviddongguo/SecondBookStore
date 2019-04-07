﻿namespace David.SecondBook.OnlineStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
