using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Additional
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public Boolean Neccessary { get; set; }
        public Boolean MantoMany { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
