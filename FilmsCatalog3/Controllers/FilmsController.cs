using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Identity;
using FilmsCatalog.Services;
using FilmsCatalog.Models.Views;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static readonly HashSet<String> AllowedExtensions = new HashSet<String> { ".jpg", ".jpeg", ".png", ".JPG", ".PNG",".JPEG" };
        private readonly UserManager<User> userManager;
        private readonly IUserPermissionService userPermissions;
        private readonly IHostingEnvironment hostingEnvironment;

        public FilmsController(ApplicationDbContext context, UserManager<User> _userManager, IUserPermissionService _service, IHostingEnvironment _host)
        {
            _context = context;
            this.userManager = _userManager;
            this.userPermissions = _service;
            this.hostingEnvironment = _host;
        }

        // GET: Films
        [AllowAnonymous]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 3;
            return this.View(await Pagination<Film>.CreateAsync(this._context.Films.Include(x=>x.Creator), pageNumber, pageSize));
        }

        // GET: Films/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var film = await _context.Films
                .Include(f => f.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return this.NotFound();
            }
         
            return this.View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return this.View(new FilmViewModel());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(ContentDispositionHeaderValue.Parse(model.File.ContentDisposition).FileName.Trim('"'));
                var fileExt = Path.GetExtension(fileName);
                if (!FilmsController.AllowedExtensions.Contains(fileExt))
                {
                    this.ModelState.AddModelError(nameof(model.File), "This file type is prohibited");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.HttpContext.User);

                var film = new Film
                {
                    Name = model.Name,
                    Description = model.Description,
                    Year = model.Year,
                    Director = model.Director,
                    CreatorId = user.Id,
                };
                var attachmentPath = Path.Combine(this.hostingEnvironment.WebRootPath, "attachments", film.Id.ToString("N") + fileExt);
                film.Path = $"/attachments/{film.Id:N}{fileExt}";
                using (var fileStream = new FileStream(attachmentPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
                {
                    await model.File.CopyToAsync(fileStream);
                }
                this._context.Add(film);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
 
            return this.View(model);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }
            var film = await this._context.Films.SingleOrDefaultAsync(x=>x.Id == id);
            if (film == null)
            {
                return this.NotFound();
            }
            var model = new EditFilmViewModel
            {
                Name = film.Name,
                Description = film.Name,
                Year = film.Year,
                Director = film.Director,
                Path = film.Path
            };
            this.ViewBag.FilmId = id;
            return this.View(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFilmViewModel model, Guid? id)
        {
           if (id == null)
            {
                return this.NotFound();
            }
            var film = await this._context.Films.SingleOrDefaultAsync(x => x.Id == id);
            if (film == null || !this.userPermissions.CanEditFilm(film))
            {
                return this.NotFound();
            }
            if (this.ModelState.IsValid)
            {
                if (model.File != null)
                {
                    var attachmentPath = Path.Combine(this.hostingEnvironment.WebRootPath, "attachments", film.Id.ToString("N") + Path.GetExtension(film.Path));
                    System.IO.File.Delete(attachmentPath);
                    var fileName = Path.GetFileName(ContentDispositionHeaderValue.Parse(model.File.ContentDisposition).FileName.Trim('"'));
                    var fileExt = Path.GetExtension(fileName);
                    if (!FilmsController.AllowedExtensions.Contains(fileExt))
                    {
                        this.ModelState.AddModelError(nameof(model.File), "This file type is prohibited");
                        return this.View(model);
                    }
                    attachmentPath = Path.Combine(this.hostingEnvironment.WebRootPath, "attachments", film.Id.ToString("N") + fileExt);
                    film.Path = $"/attachments/{film.Id:N}{fileExt}";
                    using (var fileStream = new FileStream(attachmentPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
                    {
                        await model.File.CopyToAsync(fileStream);
                    }
                    film.Path = $"/attachments/{film.Id:N}{fileExt}";
                }
                film.Name = model.Name;
                film.Description = model.Description;
                film.Year = model.Year;
                film.Director = model.Director;
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
            this.ViewBag.FilmId = id;
            return this.View(model);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var film = await this._context.Films
                .Include(f => f.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return this.NotFound();
            }

            return this.View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var film = await this._context.Films.FindAsync(id);
            var attachmentPath = Path.Combine(this.hostingEnvironment.WebRootPath, "attachments", film.Id.ToString("N") + Path.GetExtension(film.Path));
            System.IO.File.Delete(attachmentPath);
            this._context.Films.Remove(film);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

    }
}
