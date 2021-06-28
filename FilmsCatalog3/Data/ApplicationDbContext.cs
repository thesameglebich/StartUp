using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FilmsCatalog.Models;

namespace FilmsCatalog.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Film> Films { get; set; }
        
        //public DbSet<Additional> Additionals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommentDish> CommentDishes { get; set; }
        public DbSet<CommentRest> CommentRests { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderAdd> OrderAdds { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Section> Sections { get; set; }
        //public DbSet<DishIngridient> DishIngridients { get; set; }
        //public DbSet<OneTest> OneTests { get; set; }
        //public DbSet<TwoTest> TwoTests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<DishIngridientcl>().HasKey(x => new { x.DishId, x.IngridientId });
            builder.Entity<Dish>().HasMany(x => x.Ingridients).WithMany(c => c.Dishes)
               .UsingEntity<Dictionary<string, object>>("Tutelage", j => j.HasOne<Ingridient>().WithMany().OnDelete(DeleteBehavior.NoAction),
               j => j.HasOne<Dish>().WithMany().OnDelete(DeleteBehavior.NoAction));
            //builder.Entity<DishIngridient>().HasOne(x => x.Dish).WithMany().OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<DishIngridient>().HasOne(x => x.Ingridient).WithMany().OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<Section>().HasOne(x => x.Menu).WithMany().OnDelete(DeleteBehavior.Restrict);
            /*
            builder.Entity<Category>().HasMany(x => x.Dishes).WithMany(c => c.Categories)
                .UsingEntity<Dictionary<string, object>>("Tutelage", j => j.HasOne<Dish>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Category>().WithMany().OnDelete(DeleteBehavior.NoAction));
            builder.Entity<Dish>().HasMany(x => x.Ingridients).WithMany(c => c.Dishes)
                .UsingEntity<Dictionary<string, object>>("Tutelage", j => j.HasOne<Ingridient>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Dish>().WithMany().OnDelete(DeleteBehavior.NoAction));
            builder.Entity<Category>().HasMany(x => x.Sections).WithMany(c => c.Categories)
                .UsingEntity<Dictionary<string, object>>("Tutelage", j => j.HasOne<Section>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Category>().WithMany().OnDelete(DeleteBehavior.NoAction));
            builder.Entity<Menu>().HasMany(x => x.Sections).WithMany(c => c.Menus)
                .UsingEntity<Dictionary<string, object>>("Tutelage", j => j.HasOne<Section>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Menu>().WithMany().OnDelete(DeleteBehavior.NoAction));*/

            //builder.Entity<OrderDish>().HasOne(x => x.Order).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<OrderAdd>().HasOne(x => x.Order).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
