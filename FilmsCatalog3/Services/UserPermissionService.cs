using FilmsCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        public UserPermissionService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        private HttpContext HttpContext => this.httpContextAccessor.HttpContext;
        public bool CanEditFilm(Film film)
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (this.HttpContext.User.IsInRole("admin"))
            {
                return true;
            }

            return this.userManager.GetUserId(this.httpContextAccessor.HttpContext.User) == film.CreatorId;
        }
    }
}
