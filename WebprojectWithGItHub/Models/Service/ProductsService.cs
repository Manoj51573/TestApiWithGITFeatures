using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebprojectWithGItHub.Models.ServiceInterface
{
        public class Product
        {
            public string Title { get; set; }
        }

        public class ProductsService 
        {
            private readonly List<Product> Products = new List<Product>
            {
                new Product { Title= "DVD player" },
                new Product { Title= "TV" },
                new Product { Title= "Projector" }
            };

            public IEnumerable<Product> GetProducts()
            {
                return Products.AsEnumerable();
            }
        }
    }

