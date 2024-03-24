using Microsoft.AspNetCore.Mvc;
using WebApi_ZavrsniRad.Data;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetm radnik u bazi
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PodaciZaObracuneController : ControllerBase
    {
        /// <summary>
        /// Kontekst za rad s bazom koji  će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly ObracunPlacaContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Radnik kontext pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public PodaciZaObracuneController(ObracunPlacaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dohvaća sve radnike iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        ///     Get api/v1/Radnik
        /// </remarks>
        /// <returns> Radnici u bazi </returns>
        /// <response code="200">Sve OK </response>
        /// <response code="400">Zahtjev nije valjan</response>
        [HttpGet]
        public IActionResult Get ()
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var podacizaobracun = _context.PodaciZaObracune.ToList();
                if(podacizaobracun==null || podacizaobracun.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(podacizaobracun);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var podacizaobracun = _context.PodaciZaObracune.ToList();
                if (podacizaobracun == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(podacizaobracun);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        /// <summary>
        /// Dodaje novog radnika u bazu
        /// </summary>
        /// <remarks>
        ///     POST api/v1/Smjer
        ///     {naziv: "Primjer radnika"}
        /// </remarks>
        /// <param name="radnik">Smjer za unijeti u JSON formatu</param>
        /// <response code="201">Kreirano</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Baza nedostupna iz razno raznih razloga</response> 
        /// <returns>Smjer s šifrom koju je dala baza</returns>
        [HttpPost]
        public IActionResult Post(PodaciZaObracune entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {

                _context.PodaciZaObracune.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        


        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetIzbaze = _context.PodaciZaObracune.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.PodaciZaObracune.Remove(entitetIzbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
    }
}


//OVO JE  KOD ZA ZAMJENU S ENTITETOM

