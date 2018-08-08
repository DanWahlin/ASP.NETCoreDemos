using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCRUD.Models;
using EFCRUD.Repository;

namespace EFCRUD.Controllers
{
    public class MoviesController : Controller
    {
        IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _moviesRepository.ListAsync());
        }


        public async Task<ActionResult> Details(int id = 0)
        {
            return View(await _moviesRepository.FindAsync(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _moviesRepository.CreateAsync(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            return View(await _moviesRepository.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _moviesRepository.EditAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public async Task<ActionResult> Delete(int id = 0)
        {
            return View(await _moviesRepository.FindAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _moviesRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            _moviesRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
