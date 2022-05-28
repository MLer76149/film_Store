using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmStore.Models
{
    public class FilmEntities : DbContext
    {
        public FilmEntities() : base("FilmEntities")

        {



        }
        public DbSet<Filme> Filme_db { get; set; }
        public DbSet<Genres> Genres_db { get; set; }
        public DbSet<Regisseure> Regisseure_db { get; set; }
    }
}