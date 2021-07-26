using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<BookModel> _books = new List<BookModel>()
        {
            new BookModel()
            {
                Title = "Дом минималиста. Комната за комнатой, путь от хаоса к осмысленной жизни",
                AuthorName = "Беккер",
                Genre = "Саморазвитие"
            },
            new BookModel()
            {
                Title = "Тревожные люди",
                AuthorName = "Бакман",
                Genre = "Остросюжетная проза"
            },
            new BookModel()
            {
                Title = "Предел",
                AuthorName = "Лукьяненко",
                Genre = "Космическая фантастика"
            },
            new BookModel()
            {
                Title = "Звезд не хватит на всех. Коллапс Буферной Зоны",
                AuthorName = "Глебов",
                Genre = "Космическая фантастика"
            },
            new BookModel()
            {
                Title = "Выбор. О свободе и внутренней силе человека",
                AuthorName = "Эгер",
                Genre = "Биографии и мемуары"
            }
        };

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks()
        {
            return _books;
        }

        // GET api/<BookController>/AuthorName
        [HttpGet("{authorName}")]
        public IEnumerable<BookModel> GetBooksByAuthor(string authorName)
        {
            List<BookModel> result = new();
            foreach (BookModel item in _books)
            {
                if (item.AuthorName == authorName)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // POST api/<BookController>
        [HttpPost]
        public IEnumerable<BookModel> PostBook([FromBody] BookModel model)
        {
            _books.Add(model);
            return _books;
        }

        // DELETE api/<PersonController>/RemoveTask/Author/Title
        [HttpDelete("{author}/{title}")]
        public OkResult DeleteBook(string author, string title)
        {
            _books.RemoveAll(_books => (_books.AuthorName == author) & (_books.Title == title));
            return Ok();
        }
    }
}
