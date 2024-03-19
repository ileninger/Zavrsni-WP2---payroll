﻿using Microsoft.AspNetCore.Mvc;
using WebApi_ZavrsniRad.Data;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad entitetm radnik u bazi
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ObracunController : ControllerBase
    {
        /// <summary>
        /// Kontekst za rad s bazom koji  će biti postavljen s pomoću Dependecy Injection-om
        /// </summary>
        private readonly ObracunPlacaContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Radnik kontext pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public ObracunController(ObracunPlacaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var lista = _context.Obracun.ToList();
                if (lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Obracun entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Obracun.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Obracun entitet)
        {
            if (sifra <= 0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }


            try
            {


                var entitetIzBaze = _context.Obracun.Find(sifra);
                var PodaciORadniku = _context.Radnici.Find(sifra);


                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }


                // inače ovo rade mapperi
                // za sada ručno

                entitetIzBaze.DatumObracuna = entitet.DatumObracuna;
                entitetIzBaze.BrojRadnihSati = entitet.BrojRadnihSati;
                entitetIzBaze.OsnovniOsobniOdbitak = entitet.OsnovniOsobniOdbitak;
                entitetIzBaze.UdioZaPrviMirovinskiStup = entitet.UdioZaPrviMirovinskiStup;
                entitetIzBaze.UdioZaDrugiMirovinskiStup = entitet.UdioZaDrugiMirovinskiStup;
                entitetIzBaze.OsnovniOsobniOdbitak = entitet.OsnovniOsobniOdbitak;
                entitetIzBaze.PorezNaDohodak = entitet.PorezNaDohodak;

                entitetIzBaze.Bruto_I = entitetIzBaze.Bruto_I;
                entitetIzBaze.Bruto_II = entitetIzBaze.Bruto_II;
                entitetIzBaze.PoreznaOsnovica = entitetIzBaze.PoreznaOsnovica;
                entitetIzBaze.NetoIznosZaIsplatu = entitetIzBaze.NetoIznosZaIsplatu;



                _context.Obracun.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitetIzBaze);
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
                var entitetIzbaze = _context.Obracun.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Obracun.Remove(entitetIzbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

    }
}
