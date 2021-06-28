using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class OrderDish
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Int32 Count { get; set; }
        public Guid? DishId { get; set; }
        public Dish Dish { get; set; }
        //public Guid? OrderAddId { get; set; }
        //public OrderAdd OrderAdd { get; set; }

       
    }
}
