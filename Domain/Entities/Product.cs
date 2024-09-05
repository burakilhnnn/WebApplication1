using Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product:EntityBase
    {
        public Product()
        {
        }
        public Product(string title, string description, decimal price, int categoryId, string stock)
        {
            Title = title;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Stock = stock;
        }

        public string Title  { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Stock { get; set; }
    }
}
