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
    public class RadnikController:ControllerBase
    {
        /// <summary>
        /// Kontekst za rad s bazom koji  će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly ObracunPlacaContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Radnik kontext pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public RadnikController(ObracunPlacaContext context)
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
                var radnici = _context.Radnici.ToList();
                if(radnici==null || radnici.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(radnici);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Mijenja podatke postojećeg smjera u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "naziv": "Novi naziv",
        ///  "trajanje": 120,
        ///  "cijena": 890.22,
        ///  "upisnina": 0,
        ///  "verificiran": true
        /// }
        ///
        /// </remarks>
        /// <param name="sifra">Šifra smjera koji se mijenja</param>  
        /// <param name="radnik">Smjer za unijeti u JSON formatu</param>  
        /// <returns>Svi poslani podaci od smjera koji su spremljeni u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Baza nedostupna</response> 
        //[HttpPut]
        //[Route("{sifra:int}")]

        //public IActionResult Put(int sifra, Radnik radnik)
        //{
        //    if( sifra <=0 || !ModelState.IsValid || radnik == null ) 
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        var RadnikIzBaze = _context.Radnici.Find(sifra);
        //        if(RadnikIzBaze == null)
        //        {
        //            return StatusCode(StatusCodes.Status204NoContent, sifra);
        //        }
        //        RadnikIzBaze.Ime = radnik.Ime;

        //        _context.Radnici.Update(RadnikIzBaze);
        //        _context.SaveChanges();
                
        //    }catch(Exception ex) 
        //    {
        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,ex.Message);
        //    }

        //}

    }
}
