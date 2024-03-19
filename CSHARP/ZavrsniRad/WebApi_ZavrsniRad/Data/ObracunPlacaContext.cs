using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Data
{
    /// <summary>
    /// Ovo mi je datoteka gdje ću navoditi datasetove i načine spajanja u bazi
    /// </summary>
    public class ObracunPlacaContext:DbContext
    {
        /// <summary>
        /// Konstruktor proslijeđujemo konstruktor gore
        /// </summary>
        /// <param ="options"></param>
        public ObracunPlacaContext(DbContextOptions<ObracunPlacaContext> options)
            :base(options)
        {

        }
        /// <summary>
        /// Radnici u bazi
        /// </summary>

        public DbSet<Radnik> Radnici { get; set; }

        public DbSet<Obracun> Obracun { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // implementacija veze 1:n
            modelBuilder.Entity<Obracun>().HasOne(g => g.Radnik);


        }


    }
}
