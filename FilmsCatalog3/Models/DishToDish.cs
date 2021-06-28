using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class DishToDish
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FDishId { get; set; }
        public Dish FDish { get; set; }
        public Guid SDishId { get; set; }
        public Dish SDish { get; set; }
    }
}
