using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingEntityFrameworkCore.Repository;
using UsingEntityFrameworkCore.Models;

namespace UsingEntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        CustomersDbContext _context;

        public HomeController(CustomersDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var newCustomer = new Customer { Name="Michelle Thomas", City="Los Angeles" };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            var customer = _context.Customers.FirstOrDefault();
            return View(customer);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
