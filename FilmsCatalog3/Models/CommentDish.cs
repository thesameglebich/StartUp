using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class CommentDish
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Comment { get; set; }
        public String Phone { get; set; }
        public String Name { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
