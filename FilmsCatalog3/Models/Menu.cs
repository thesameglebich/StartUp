using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Menu
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Section> Sections { get; set; }

    }
}
