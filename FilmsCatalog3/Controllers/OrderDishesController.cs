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
    public class OrderDishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderDishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDishes.Include(o => o.Dish).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderDishes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDish = await _context.OrderDishes
                .Include(o => o.Dish)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDish == null)
            {
                return NotFound();
            }

            return View(orderDish);
        }

        // GET: OrderDishes/Create
        public IActionResult Create()
        {
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: OrderDishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,Count,DishId")] OrderDish orderDish)
        {
            if (ModelState.IsValid)
            {
                orderDish.Id = Guid.NewGuid();
                _context.Add(orderDish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", orderDish.DishId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDish.OrderId);
            return View(orderDish);
        }

        // GET: OrderDishes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDish = await _context.OrderDishes.FindAsync(id);
            if (orderDish == null)
            {
                return NotFound();
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", orderDish.DishId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDish.OrderId);
            return View(orderDish);
        }

        // POST: OrderDishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderId,Count,DishId")] OrderDish orderDish)
        {
            if (id != orderDish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDishExists(orderDish.Id))
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
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", orderDish.DishId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDish.OrderId);
            return View(orderDish);
        }

        // GET: OrderDishes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDish = await _context.OrderDishes
                .Include(o => o.Dish)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDish == null)
            {
                return NotFound();
            }

            return View(orderDish);
        }

        // POST: OrderDishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orderDish = await _context.OrderDishes.FindAsync(id);
            _context.OrderDishes.Remove(orderDish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDishExists(Guid id)
        {
            return _context.OrderDishes.Any(e => e.Id == id);
        }
    }
}
