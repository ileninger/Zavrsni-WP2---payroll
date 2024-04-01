using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApi_ZavrsniRad.Data;
using WebApi_ZavrsniRad.Extensions;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetm radnik u bazi
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ObracuniController : ControllerBase
    {

        private readonly ObracunPlacaContext _context;
        public ObracuniController(ObracunPlacaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var obracuni = _context.Obracuni
                    .Include(g=>g.Radnik)
                    .Include(g=>g.PodaciZaObracune)
                    .Include(g=>g.Placa)
                    .ToList();

                if (obracuni == null || obracuni.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(obracuni);
            }
            catch (Exception ex)
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
                var obracuni = _context.Obracuni.Find(sifra);
                if (obracuni == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(obracuni);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Obracun entitet, int sifra)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                var entitetIzStupcaObracuni = _context.Obracuni.Find(sifra);
                var entitetIzStupcaRadnik = _context.Radnici.Find(sifra);
                var entitetIzStupcaPlace = _context.Place.Find(sifra);
                var entitetIzStupcaPodaciZaObracun = _context.PodaciZaObracune.Find(sifra);


                if (entitetIzStupcaObracuni == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                entitetIzStupcaObracuni.DatumObracuna = entitetIzStupcaObracuni.DatumObracuna;
                
                entitetIzStupcaObracuni.Bruto_I = entitetIzStupcaRadnik.CijenaRadnogSata * entitetIzStupcaRadnik.KoeficijentRadnogMjesta * entitetIzStupcaPlace.BrojRadnihSati;
                entitetIzStupcaObracuni.UdioZaPrviMirovinskiStup = entitetIzStupcaPodaciZaObracun.PostotakZaPrviMirovinskiStup * entitetIzStupcaObracuni.Bruto_I;
                entitetIzStupcaObracuni.UdioZaDrugiMirovinskiStup = entitetIzStupcaPodaciZaObracun.PostotakZaDrugiMirovinskiStup * entitetIzStupcaObracuni.Bruto_I;

                entitetIzStupcaObracuni.Bruto_II = entitetIzStupcaObracuni.Bruto_I - (entitetIzStupcaObracuni.UdioZaPrviMirovinskiStup + entitetIzStupcaObracuni.UdioZaDrugiMirovinskiStup);

                entitetIzStupcaObracuni.PoreznaOsnovicaPorezaNaDohodak = entitetIzStupcaObracuni.Bruto_II - entitetIzStupcaPodaciZaObracun.OsnovniOsobniOdbitak;

                entitetIzStupcaObracuni.NetoIznosZaIsplatu = entitetIzStupcaObracuni.Bruto_II - (entitetIzStupcaObracuni.PoreznaOsnovicaPorezaNaDohodak * entitetIzStupcaPodaciZaObracun.StopaPorezaNaDohodak);




                _context.Obracuni.Add(entitet);

                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        //[HttpPut]
        //[Route("{sifra:int}")]
        //public IActionResult Put(int sifra, PodaciZaObracune entitet)
        //{
        //    if (sifra <= 0 || !ModelState.IsValid || entitet == null)
        //    {
        //        return BadRequest();
        //    }


        //    try
        //    {


        //        var entitetIzBaze = _context.PodaciZaObracune.Find(sifra);


        //        if (entitetIzBaze == null)
        //        {
        //            return StatusCode(StatusCodes.Status204NoContent, sifra);
        //        }



        //        // inače ovo rade mapperi
        //        // za sada ručno
        //        //entitetIzBaze.BrojRadnihSati = entitet.BrojRadnihSati;
        //        entitetIzBaze.OsnovniOsobniOdbitak = entitet.OsnovniOsobniOdbitak;
        //        entitetIzBaze.StopaPorezaNaDohodak = entitet.StopaPorezaNaDohodak;
        //        entitetIzBaze.PostotakZaPrviMirovinskiStup = entitet.PostotakZaPrviMirovinskiStup;
        //        entitetIzBaze.PostotakZaDrugiMirovinskiStup = entitet.PostotakZaDrugiMirovinskiStup;

        //        _context.PodaciZaObracune.Update(entitetIzBaze);
        //        _context.SaveChanges();

        //        return StatusCode(StatusCodes.Status200OK, entitetIzBaze);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,
        //            ex.Message);
        //    }
        //}
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
                var entitetIzbaze = _context.Obracuni.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Obracuni.Remove(entitetIzbaze);
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

