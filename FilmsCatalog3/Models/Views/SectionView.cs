using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models.Views
{
    public class SectionView
    {
        public String Name { get; set; }
        public Guid CompanyId { get; set; }
        public Boolean Actice { get; set; }
        public Guid Menu { get; set; }
        public Guid Id { get; set; }

    }
}
