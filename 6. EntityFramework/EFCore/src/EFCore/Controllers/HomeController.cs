using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Repository;

namespace EFCore.Controllers
{
    public class HomeController : Controller
    {
        IMoviesRepository _repository;

        public HomeController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _repository.GetMovies();
            return View(movies);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
