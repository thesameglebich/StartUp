using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Place
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Int32 Number { get; set; }
        public Boolean Active { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
