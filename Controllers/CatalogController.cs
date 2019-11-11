using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTHomework.Models;

namespace RESTHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly BookCatalogContext _db;
        private readonly IHttpContextAccessor _accessor;
        public CatalogController(BookCatalogContext context, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _db = context;

            if (!_db.Genres.Any())
            {
                _db.Genres.Add(new Genre { Name = "Detective" });   // ID = 1
                _db.Genres.Add(new Genre { Name = "Fantastic" });   // ID = 2
                _db.Genres.Add(new Genre { Name = "Fantasy" });     // ID = 3
                _db.Genres.Add(new Genre { Name = "Poetry" });      // ID = 4
                _db.Genres.Add(new Genre { Name = "Romance" });       // ID = 5
                _db.Genres.Add(new Genre { Name = "Horror" });      // ID = 6
                _db.SaveChanges();
            }

            // if database doesn't consists any books, add two new books to database
            if (!_db.Books.Any())
            {
                _db.Books.Add(new Book { Title = "Чужак", Author = "Стивен Кинг", GenreId = 1, Year = 2019, Publisher = "Neoclassic" });
                _db.Books.Add(new Book { Title = "Смертельная белизна", Author = "Роберт Гэлбрэйт", GenreId = 1, Year = 2019, Publisher = "Азбука-Аттикус" });

                _db.Books.Add(new Book { Title = "Шаровая молния", Author = "Лю Цысинь", GenreId = 2, Year = 2019, Publisher = "Fanzon" });
                _db.Books.Add(new Book { Title = "11/22/63", Author = "Стивен Кинг", GenreId = 2, Year = 2017, Publisher = "ACT" });

                _db.Books.Add(new Book { Title = "Гарри Поттер и узник Азкабана", Author = "Дж. К. Роулинг", GenreId = 3, Year = 2017, Publisher = "Pottermore" });
                _db.Books.Add(new Book { Title = "Игра престолов", Author = "Джордж Мартин", GenreId = 3, Year = 2019, Publisher = "ACT" });

                _db.Books.Add(new Book { Title = "Ворон", Author = "Эдгар Аллан По", GenreId = 4, Year = 2013, Publisher = "Азбука" });
                _db.Books.Add(new Book { Title = "Цветы зла", Author = "Шарль Бодлер", GenreId = 4, Year = 2017, Publisher = "Азбука" });

                _db.Books.Add(new Book { Title = "Королева Марго", Author = "Александр Дюма", GenreId = 5, Year = 2018, Publisher = "Азбука" });
                _db.Books.Add(new Book { Title = "С любовью, Рози", Author = "Сесилия Ахерн", GenreId = 5, Year = 2015, Publisher = "Иностранка" });

                _db.Books.Add(new Book { Title = "Зелёная миля", Author = "Стивен Кинг", GenreId = 6, Year = 2017, Publisher = "ACT" });
                _db.Books.Add(new Book { Title = "Пустая могила", Author = "Джонатан Страуд", GenreId = 6, Year = 2018, Publisher = "Эксмо" });

                _db.SaveChanges();
            }
        }

        // get all genres from table
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _db.Genres.ToList();
        }

        // get all books by genre from table
        [HttpGet("{genreId}")]
        public IEnumerable<Book> Get(int genreId)
        {
            List<Book> books = _db.Books.Where(b => b.GenreId == genreId).ToList();
            return _db.Books.Where(b => b.GenreId == genreId).ToList();
        }
    }
}