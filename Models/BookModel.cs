using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Backend.Models
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public string Genre { get; set; }
    }
}
