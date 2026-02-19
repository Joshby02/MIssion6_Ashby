using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission6_Ashby.Data;
using Mission6_Ashby.Models;

namespace Mission6_Ashby.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: Movies (List all movies)
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .OrderBy(m => m.Title)
                .ToListAsync();
            
            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            // Get unique directors from existing movies
            ViewBag.Directors = new SelectList(_context.Movies.Where(m => m.Director != null).Select(m => m.Director).Distinct().OrderBy(d => d).ToList());
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R", "NC-17", "NR" });
            
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Year,Director,Rating,Edited,LentTo,Notes,CopiedToPlex")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Movie added successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Directors = new SelectList(_context.Movies.Where(m => m.Director != null).Select(m => m.Director).Distinct().OrderBy(d => d).ToList(), movie.Director);
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R", "NC-17", "NR" }, movie.Rating);
            
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Directors = new SelectList(_context.Movies.Where(m => m.Director != null).Select(m => m.Director).Distinct().OrderBy(d => d).ToList(), movie.Director);
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R", "NC-17", "NR" }, movie.Rating);
            
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Year,Director,Rating,Edited,LentTo,Notes,CopiedToPlex")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Movie updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Directors = new SelectList(_context.Movies.Where(m => m.Director != null).Select(m => m.Director).Distinct().OrderBy(d => d).ToList(), movie.Director);
            ViewBag.Ratings = new SelectList(new[] { "G", "PG", "PG-13", "R", "NC-17", "NR" }, movie.Rating);
            
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Movie deleted successfully!";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
