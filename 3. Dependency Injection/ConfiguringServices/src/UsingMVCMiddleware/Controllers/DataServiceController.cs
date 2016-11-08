using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringServices.Models;

namespace ConfiguringServices.Controllers
{
    [Route("api/[controller]")]
    public class DataServiceController : Controller
    {
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

        [HttpGet("customers")]
        public IActionResult Customers()
        {
            try
            {
                throw new InvalidOperationException();
                //return Ok();
            }
            catch (Exception exp)
            {
                throw;
                //return HttpNotFound();
            }
        }
    }
}
