using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")] 
    public class DataServiceController : Controller
    {
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

        [HttpGet("customers/{id:int}")]
        public IActionResult Customers(int id)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe"
            };
            return Ok(customer);
        }
    }
}
