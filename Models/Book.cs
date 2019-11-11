using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTHomework.Models
{
    public class Book
    {
        //enum GenreType { Detective, Fantastic, Fantasy, Poetry, Historical, Horror, Religious }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int Year { get; set; }

        public string Publisher { get; set; }
    }
}
