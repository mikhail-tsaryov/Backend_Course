using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Backend_1.Models;

namespace Backend_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks()
        {
            using (var dbContext = new ApplicationContext())
            {
                var allBooks = dbContext.Books.ToList();
                return allBooks;
            }   
        }

        // GET api/<BookController>/AuthorName
        [HttpGet("{authorName}")]
        public IEnumerable<BookModel> GetBooksByAuthor(string authorName)
        {
            using (var dbContext = new ApplicationContext())
            {
                var book = dbContext.Books
                    .Where(b => b.AuthorName == authorName)
                    .ToList();
                return book;
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public IEnumerable<BookModel> PostBook(string author, string title, string genre)
        {
            BookModel newBook = new BookModel()
            {
                Title = title,
                AuthorName = author,
                Genre = genre
            };
            using (var dbContext = new ApplicationContext())
            {
                var persons = dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
                var allBooks = dbContext.Books.ToList();
                return allBooks;
            }
        }

        // DELETE api/<PersonController>/Author/Title
        [HttpDelete("{author}/{title}")]
        public IActionResult DeleteBook(string author, string title)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    var book = dbContext.Books
                        .Where(b => (b.AuthorName == author) & (b.Title == title)).First();
                    dbContext.Remove(book);
                    dbContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok("Book not found");
                throw;
            }            
        }
    }
}
