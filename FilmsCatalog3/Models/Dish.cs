using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Dish
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public Boolean Active { get; set; }
        public String Description { get; set; }
        public Int32 Price { get; set; }
        public Double Weight { get; set; }
        public Int32 Calor { get; set; }
        public String Time { get; set; }
        public String Path { get; set; }
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public String Alerg { get; set; }
        public String Birka { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        //public ICollection<DishIngridient> DishIngridients { get; set; }
        //public ICollection<Category> Categories { get; set; }
        public ICollection<Ingridient> Ingridients { get; set; }
        //public ICollection<Additional> Additionals { get; set; }

    }
}
