using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebprojectWithGItHub.Models.Helpers;


namespace WebprojectWithGItHub.Models.ServiceInterface
{
   public interface IProductsService
    {
        IEnumerable<Product> GetProducts();

       Employee GetEmployee(int Id);
    }
}
