using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class Film
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public String Description { get; set; }
        [Required]
        [Range(1895, 2200)]
        public Int32 Year { get; set; }
        [Required]
        public String Director { get; set; }
        [Required]
        public String CreatorId { get; set; }
        public User Creator { get; set; }
        [Required]
        public String Path { get; set; }

    }
}
