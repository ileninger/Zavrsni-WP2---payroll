using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        /// <param name="options"></param>
        public ObracunPlacaContext(DbContextOptions<ObracunPlacaContext> options)
            :base(options)
        {

        }
        /// <summary>
        /// Radnici u bazi
        /// </summary>

        [Key]
        public DbSet<Radnik> Radnici { get; set; }

    }
}
