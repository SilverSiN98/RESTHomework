using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTHomework.Models;

namespace RESTHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueriesController : ControllerBase
    {
        private readonly BookCatalogContext _db;
        private readonly IHttpContextAccessor _accessor;
        public QueriesController(BookCatalogContext context, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _db = context;
            if(!_db.Genres.Any())
            {
                _db.Genres.Add(new Genre { Name = "Detective" });   // ID = 1
                _db.Genres.Add(new Genre { Name = "Fantastic" });   // ID = 2
                _db.Genres.Add(new Genre { Name = "Fantasy" });     // ID = 3
                _db.Genres.Add(new Genre { Name = "Poetry" });      // ID = 4
                _db.Genres.Add(new Genre { Name = "Historical" });  // ID = 5
                _db.Genres.Add(new Genre { Name = "Horror" });      // ID = 6
                _db.SaveChanges();
            }

            // if database doesn't consists any books, add two new books to database
            if (!_db.Books.Any())
            {
                _db.Books.Add(new Book { Title = "Игра престолов", Author = "Джордж Мартин", GenreId = 3, Year = 2019, Publisher = "ACT" });
                _db.Books.Add(new Book { Title = "Чужак", Author = "Стивен Кинг", GenreId = 1, Year = 2019, Publisher = "Neoclassic" });
                _db.SaveChanges();
            }
        }

        // get book by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book book = _db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        // add new book to table
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(book);
        }

        // edit existing book from table
        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!_db.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }

            _db.Update(book);
            _db.SaveChanges();
            return Ok(book);
        }

        // delete book by id from table
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = _db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return Ok(book);
        }
    }
}