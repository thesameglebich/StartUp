using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models.Views
{
    public class EditFilmViewModel
    {
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public String Description { get; set; }
        [Range(1895, 2200)]
        public Int32 Year { get; set; }
        [Required]
        public String Director { get; set; }
        public IFormFile File { get; set; }
        public String Path { get; set; }
    }
}
