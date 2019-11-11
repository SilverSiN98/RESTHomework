using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTHomework.Models
{
    public class BookCatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookCatalogContext(DbContextOptions<BookCatalogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
