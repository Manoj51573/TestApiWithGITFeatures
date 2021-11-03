using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebprojectWithGItHub.Models;
using WebprojectWithGItHub.Models.ServiceInterface;

namespace WebprojectWithGItHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _productService;

        //Home controller has a dependency on IProductsService, home controller is not creating a object of ProductsService by using new keyword instead we are injecting a IProductsService dependency in this controller class by using 
        //its  constructor, and this is called constructor injection.
        //when someone like home controller will request IProductsService depencencies, we want asp.net to create an instance of an implementation this interface IProductsService.
        //when someone will request IProductsService depencencies asp.net to create an instance of ProductsService and inject that into the controller.
        //for this we have to register interface IProductsService and its implementation of class ProductsService in Startup.cs
        // services.AddScoped<IProductsService, ProductsService>();

        //Benefits of DI
            //Loose Coupling
            //Easy to unit Test


        public HomeController(ILogger<HomeController> logger, IProductsService ProductsService)
        {
            _logger = logger;
            _productService= ProductsService;
        }

        public IActionResult Index()
        {
            var viewModel = _productService.GetProducts();
          //  return View();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
