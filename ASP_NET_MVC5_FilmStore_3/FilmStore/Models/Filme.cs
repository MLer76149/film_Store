using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmStore.Models
{
    public class Filme
    {
        [Key]
        public int FilmId { get; set; }
        public int GenreId { get; set; }
        public int RegisseurId { get; set; }
        public string Title { get; set; }
        public string FilmArtUrl { get; set; }
        public Genres Genre { get; set; }
        public Regisseure Regisseur { get; set; }
        
    }
}