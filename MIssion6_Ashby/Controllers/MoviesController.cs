using Mission6_Ashby.Data;
using Mission6_Ashby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mission6_Ashby.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName");
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"'{movie.Title}' has been added to the collection!";
                return RedirectToAction(nameof(Create));
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName", movie.DirectorId);
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R" });
            return View(movie);
        }
    }
}