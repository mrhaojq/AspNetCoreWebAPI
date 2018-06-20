using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        Product[] products = new Product[]
           {
                new Product{Id=1,Name="Tomato Soup",Category="Groceries",Price=1 },
                new Product{ Id=2,Name="Yo-yo",Category="Toys",Price=3.75M},
                new Product{ Id=3,Name="Hammer",Category="Hardware",Price=16.99M}
           };

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet]
        public Product GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}