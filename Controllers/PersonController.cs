using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<PersonModel> _persons = new List<PersonModel>()
        {
            new PersonModel()
            {
                Surname = "Горбунов",
                Name = "Николай",
                MiddleName = "Дмитриевич",
                DateOfBirthday = new DateTime(1964, 5, 12)
            },

            new PersonModel()
            {
                Surname = "Соловьёв",
                Name = "Вениамин",
                MiddleName = "Григорьевич",
                DateOfBirthday = new DateTime(1986, 1, 1)
            },

            new PersonModel()
            {
                Surname = "Лихачёв",
                Name = "Орест",
                MiddleName = "Кимович",
                DateOfBirthday = new DateTime(2000, 10, 30)
            },

            new PersonModel()
            {
                Surname = "Зуев",
                Name = "Митрофан",
                MiddleName = "Аркадьевич",
                DateOfBirthday = new DateTime(1939, 6, 18)
            },

            new PersonModel()
            {
                Surname = "Назаров",
                Name = "Елисей",
                MiddleName = "Наумович",
                DateOfBirthday = new DateTime(1997, 12, 6)
            }
        };

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonModel> GetAllPersons()
        {
            return _persons;
        }

        // GET api/<PersonController>/PersonName
        [HttpGet("{personName}")]
        public IEnumerable<PersonModel> GetPersonByName(string personName)
        {
            List<PersonModel> result = new List<PersonModel>();
            foreach (PersonModel item in _persons)
            {
                if (item.Name == personName)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] PersonModel model)
        {
            _persons.Add(model);
            GetAllPersons();
        }

        // DELETE api/<PersonController>/Remove/Surname/Name/MiddleName
        [HttpDelete("Remove/{surname}/{name}/{middleName}")]
        public OkResult DeletePerson(string surname, string name, string middleName)
        {
            _persons.RemoveAll(_persons => (_persons.Surname == surname) & (_persons.Name == name) & (_persons.MiddleName == middleName));
            return Ok();
        }
    }
}
