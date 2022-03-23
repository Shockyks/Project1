using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models;

namespace Projekat1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlasaController : ControllerBase
    {
        public ContextKlasa Context { get; set; }

        public KlasaController(ContextKlasa context)
        {
            Context = context;
        }
    [Route("PronadjiKlase")]
        [HttpGet]
        public async Task<ActionResult> PronadjiKlase()
        {
            try
            {
                var klasa = await Context.Klase.ToListAsync();

                return Ok(klasa);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

        }
    }
}