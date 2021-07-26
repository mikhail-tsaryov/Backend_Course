using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_1
{
    public class PersonDTO
    {
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirthday { get; set; }
    }
}
