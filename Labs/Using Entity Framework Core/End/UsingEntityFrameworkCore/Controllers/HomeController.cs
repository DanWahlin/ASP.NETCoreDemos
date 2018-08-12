using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsingEntityFrameworkCore.Repository;
using UsingEntityFrameworkCore.Models;

namespace UsingEntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        CustomersDbContext _context;
        ICustomersRepository _repo;

        public HomeController(CustomersDbContext dbContext, ICustomersRepository repo)
        {
            _context = dbContext;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            // Insert and retrieve a single customer
            // var newCustomer = new Customer { Name="Michelle Thomas", City="Los Angeles" };
            // _context.Customers.Add(newCustomer);
            // await _context.SaveChangesAsync();
            // var customer = await _context.Customers.FirstOrDefaultAsync();
            // return View(customer);

            // Call a repository class that retrieves multiple customers
            return View(await _repo.InsertAndRetrieveCustomerAsync());

            // Retrieve all customers
            //return View(await _repo.GetCustomersAsync());
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
