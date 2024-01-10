using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movie10.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace movie10.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovContext _context;
        IWebHostEnvironment _appEnvironment;
        public MoviesController(MovContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public bool MovieExists(string? title, int? year, string? director)////ДОБАВЛЕНО
        {
            // Проверяем, есть ли фильм с такими же title, year и director в базе данных
            return _context.Movies.Any(m =>
                m.Title == title &&
                m.Year == year &&
                m.Director == director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile uploadedFile, [Bind("Id,Title,TitleEng,Genre,Director,Year,Description,Poster")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (MovieExists(movie.Title, movie.Year, movie.Director))
                {
                    ///ДОБАВЛЕНО. РАБОТАЕТ
                    return View("~/Views/Movies/Error.cshtml", "Ошибочка вышла");
                }
            //C: \Users\User\source\repos\movie10\movie10\Views\Movies\Error.cshtml
                if (uploadedFile != null)
                {
                    // Путь к папке Files
                    string path = "/img/" + uploadedFile.FileName; // имя файла

                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                    }
                    movie.Poster = path;
                }
                // Проверка формата файла постера
                if (movie.Poster != null)
                {
                    var format = new[] { ".jpg", ".jpeg" };
                    var fileFormat = Path.GetExtension(movie.Poster).ToLower();

                    if (!format.Contains(fileFormat))
                    {
                        ModelState.AddModelError("Poster", "Допускаются только файлы с расширением .jpg или .jpeg");
                        return View(movie);
                    }
                    var maxFileSizeInBytes = 2 * 1024 * 1024; // ограничение до 2MB
                    if (movie.Poster.Length > maxFileSizeInBytes)
                    {
                        ModelState.AddModelError("Poster", "Превышен максимально допустимый размер файла.");
                        return View(movie);

                    }
                }

                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,TitleEng,Genre,Director,Year,Description,Poster")] Movie movie, IFormFile? uploadedFile)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    // Путь к папке Files
                    string path = "/img/" + uploadedFile.FileName; // имя файла
                    //movie.Poster = path;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                    }
                    movie.Poster = path;

                }
                else
                {
                    movie.Poster = (from m in _context.Movies where m.Id == id select m).FirstOrDefault().Poster; //оставляем прежний постер 
                }

                // Проверка формата файла постера
                if (movie.Poster != null)
                {
                    var format = new[] { ".jpg", ".jpeg" };
                    var fileFormat = Path.GetExtension(movie.Poster).ToLower();

                    if (!format.Contains(fileFormat))
                    {
                        ModelState.AddModelError("Poster", "Допускаются только файлы с расширением .jpg или .jpeg");
                        return View(movie);
                    }
                    var maxFileSizeInBytes = 2 * 1024 * 1024; // ограничение до 2MB
                    if (movie.Poster.Length > maxFileSizeInBytes)
                    {
                        ModelState.AddModelError("Poster", "Превышен максимально допустимый размер файла.");
                        return View(movie);

                    }
                }

                _context.Update(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
