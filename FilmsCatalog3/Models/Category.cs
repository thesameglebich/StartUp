using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Desc { get; set; }
        public Boolean Active { get; set; }
        //public ICollection<Section> Sections { get; set; }
        public Guid? SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }



    }
}
