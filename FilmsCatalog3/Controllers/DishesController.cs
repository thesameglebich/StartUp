using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Data;
using FilmsCatalog.Models;

namespace FilmsCatalog.Controllers
{
    public class DishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dishes.Include(d => d.Category).Include(d => d.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.Category)
                .Include(d => d.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: Dishes/Create
        public IActionResult Create(Guid? restId, Guid? catId)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewBag.RestId = restId;
            ViewBag.CatId = catId;
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Active,Description,Price,Weight,Calor,Time,Path,CategoryId,Alerg,Birka,CompanyId")] Dish dish, Guid? restId, Guid? catId)
        {
            if (ModelState.IsValid)
            {
                dish.Id = Guid.NewGuid();
                dish.CategoryId = catId;
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Restaurants", new { id = restId });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", dish.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", dish.CompanyId);
            return View(dish);
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", dish.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", dish.CompanyId);
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Active,Description,Price,Weight,Calor,Time,Path,CategoryId,Alerg,Birka,CompanyId")] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", dish.CategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", dish.CompanyId);
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(Guid? id, Guid? restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.Category)
                .Include(d => d.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewBag.RestId = restId;
            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid? restId)
        {
            var dish = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Restaurants", new { id = restId });
        }

        private bool DishExists(Guid id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
