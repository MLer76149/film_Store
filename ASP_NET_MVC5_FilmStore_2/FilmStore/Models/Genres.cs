using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmStore.Models
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Filme> Films { get; set; }
    }
}