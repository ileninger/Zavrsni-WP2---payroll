using Microsoft.AspNetCore.Mvc;
using WebApi_ZavrsniRad.Data;
using WebApi_ZavrsniRad.Models;
namespace WebApi_ZavrsniRad.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ObracunController:ControllerBase
    {
        private readonly ObracunPlacaContext _context;

        public ObracunController(ObracunPlacaContext context)
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
                var obracuni = _context.Obracuni.ToList();
                if(obracuni==null || obracuni.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(obracuni);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }
             

    }
}
