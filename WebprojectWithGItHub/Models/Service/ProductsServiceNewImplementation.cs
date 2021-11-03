using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebprojectWithGItHub.Models.Helpers;

namespace WebprojectWithGItHub.Models.ServiceInterface
{
        public class ProductsServiceNewImplementation : IProductsService
        {
            private List<Employee> _employeeList;
            public ProductsServiceNewImplementation()
            {
            _employeeList = new List<Employee>()
                {
                    new Employee(){Id =1, Department="computer", Email="manojformail@gmail.com"}
                };
            }

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

            public Employee GetEmployee(int id)
            {
            return _employeeList.Single(A => A.Id == id);
            }
    }
    }

