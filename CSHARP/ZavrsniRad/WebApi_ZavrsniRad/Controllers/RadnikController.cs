using Microsoft.AspNetCore.Mvc;
using WebApi_ZavrsniRad.Data;

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
            return new JsonResult(_context.Radnici.ToList());
        }

    }
}
