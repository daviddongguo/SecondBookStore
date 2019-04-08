﻿namespace David.SecondBook.OnlineStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
