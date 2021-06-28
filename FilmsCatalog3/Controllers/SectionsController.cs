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
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sections.Include(s => s.Company).Include(s => s.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Company)
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create(Guid? restId, Guid? menuId)
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            ViewBag.RestId = restId;
            ViewBag.MenuId = menuId;
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Actice,CompanyId,MenuId")] Section section, Guid? restId, Guid? menuId)
        {
            if (ModelState.IsValid)
            {
                section.Id = Guid.NewGuid();
                section.MenuId = menuId;
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Restaurants", new { id = restId});
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", section.CompanyId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", section.MenuId);
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", section.CompanyId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", section.MenuId);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Actice,CompanyId,MenuId")] Section section)
        {
            if (id != section.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", section.CompanyId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", section.MenuId);
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(Guid? id, Guid? restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Company)
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (section == null)
            {
                return NotFound();
            }
            ViewBag.RestId = restId;
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid? restId)
        {
            var section = await _context.Sections.FindAsync(id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Restaurants", new { id = restId });
        }

        private bool SectionExists(Guid id)
        {
            return _context.Sections.Any(e => e.Id == id);
        }
    }
}
