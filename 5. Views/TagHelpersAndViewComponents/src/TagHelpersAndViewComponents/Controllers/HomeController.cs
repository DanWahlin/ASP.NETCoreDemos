using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagHelpersAndViewComponents.Models;

namespace TagHelpersAndViewComponents.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new Person { FirstName = "Heedy", LastName = "Wahlin" };
            return View(vm);
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
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
