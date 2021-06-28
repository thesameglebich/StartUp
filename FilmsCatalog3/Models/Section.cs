using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Section
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public Boolean Actice { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company  { get; set; }
        public Guid? MenuId { get; set; }
        public Menu Menu { get; set; }
        //public ICollection<Menu> Menus { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public ICollection<Additional> Additionals { get; set; }

    }
}
