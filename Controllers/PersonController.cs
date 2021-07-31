using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_1.Models;

namespace Backend_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonModel> GetAllPersons()
        {
            using (var dbContext = new ApplicationContext())
            {
                var allPersons = dbContext.Persons.ToList();
                return allPersons;
            }
        }

        // GET api/<PersonController>/PersonName
        [HttpGet("{personName}")]
        public IEnumerable<PersonModel> GetPersonByName(string personName)
        {
            using (var dbContext = new ApplicationContext())
            {
                var persons = dbContext.Persons
                    .Where(p => p.Name == personName)
                    .ToList();
                return persons;
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public IEnumerable<PersonModel> Post(string surname, string name, string middleName, DateTime birthDate)
        {
            PersonModel newPerson = new PersonModel()
            {
                Surname = surname,
                Name = name,
                MiddleName = middleName,
                DateOfBirthday = birthDate
            };
            using (var dbContext = new ApplicationContext())
            {
                var persons = dbContext.Persons.Add(newPerson);
                dbContext.SaveChanges();
                var allPersons = dbContext.Persons.ToList();
                return allPersons;
            }
        }

        // DELETE api/<PersonController>/Remove/Surname/Name/MiddleName
        [HttpDelete("{surname}/{name}/{middleName}")]
        public IActionResult DeletePerson(string surname, string name, string middleName)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    var person = dbContext.Persons
                        .Where(p => (p.Surname == surname) & (p.Name == name) & (p.MiddleName == middleName)).First();

                    dbContext.Remove(person);
                    dbContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok("Person not found"); ;
                throw;
            }
        }
    }
}
