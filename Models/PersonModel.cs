using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Backend.Models
{
    /// <summary>
    ///     Person model
    /// </summary>
    public class PersonModel
    {
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirthday { get; set; }
    }
}
