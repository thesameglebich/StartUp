using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Ingridient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public Boolean Alergen { get; set; }
        public Boolean Active { get; set; }
        //public ICollection<DishIngridient> DishIngridients { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
