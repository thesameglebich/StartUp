using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class OneTest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public ICollection<TwoTest> TwoTests { get; set; }

    }
}
