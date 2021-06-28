using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        public String Description { get; set; }
        public String Domen { get; set; }
        public String WebSite { get; set; }
        public Int32 BackColor { get; set; }
        public Int32 FontColor { get; set; }
        public Int32 ButtonColor { get; set; }
        public String PathLogo { get; set; }
        public String PathWrap { get; set; }
        public String CreatorId { get; set; }
        public User Creator { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public ICollection<Ingridient> Ingridients { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public ICollection<Additional> Additionals { get; set; }

    }
}
