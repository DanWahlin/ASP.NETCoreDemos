using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using UsingOAuth.Models;

namespace UsingOAuth.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            OAuthUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = new OAuthUser();
                user.Name = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                user.AccessToken = await HttpContext.GetTokenAsync("access_token");
            }
            return View(user);
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
