using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class TwoTest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public ICollection<OneTest> OneTests { get; set; }
    }
}
