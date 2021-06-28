using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public String Adress { get; set; }
        public String WiFi { get; set; }
        public String Phone { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Guid? MenuId { get; set; }
        public Menu Menu { get; set; } 
        public ICollection<CommentRest> CommentRests { get; set; }



    }
}
