using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class OrderAdd
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? AdditionalId { get; set; }
        public Additional Additional { get; set; }
        public Int32 Count { get; set; }

    }
}
