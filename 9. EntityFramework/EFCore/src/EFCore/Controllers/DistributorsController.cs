using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Views.Home
{
    public class DistributorsController : Controller
    {
        IMoviesRepository _repository;

        public DistributorsController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var dists = await _repository.GetDistributors();
            return View(dists);
        }
    }
}