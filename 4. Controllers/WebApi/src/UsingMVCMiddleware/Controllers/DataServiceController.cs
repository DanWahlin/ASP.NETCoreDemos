using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DataServiceController : Controller
    {
        [HttpGet("customers/{id:int}")]
        public Customer Customers(int id)
        {
            return new Customer
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe"
            };
        }

        [HttpGet("customers")]
        public IActionResult Customers()
        {
            var custs = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Jane", LastName = "Doe" },
                new Customer { Id = 2, FirstName = "John", LastName = "Doe" }
            };

            return Ok(custs);
        }
    }
}
