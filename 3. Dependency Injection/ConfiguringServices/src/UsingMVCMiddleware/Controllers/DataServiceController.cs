using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ConfiguringServices.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfiguringServices.Controllers
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
