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