using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmStore.Models
{
    public class Regisseure
    {
        [Key]
        public int RegisseurId { get; set; }
        public string Name { get; set; }
        public List<Filme> Films { get; set; }
    }
}