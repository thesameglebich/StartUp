using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class CommentRest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int GraduateService { get; set; }
        public int GraduateMenu { get; set; }
        public String DataUser { get; set; }
        public Guid RestId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

    }
}
