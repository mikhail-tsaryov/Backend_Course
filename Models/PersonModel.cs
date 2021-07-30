using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_1.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime DateOfBirthday { get; set; }
    }
}
