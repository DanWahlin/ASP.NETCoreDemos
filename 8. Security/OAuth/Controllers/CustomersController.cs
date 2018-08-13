using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsingOAuth.Models;

namespace UsingOAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        public IActionResult Get()
        {
            return Ok(new Customer { Id=1, Name="John Doe", City="Phoenix" });
        }
    }
}