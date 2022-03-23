using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models;

namespace WebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LetController : ControllerBase
    {
        public ContextKlasa Context { get; set; }

        public LetController(ContextKlasa context)
        {
            Context = context;
        }

        [Route("PronadjiLetove/{aerodromID}")]
        [HttpGet]
        public async Task<ActionResult> PronadjiLetove(int aerodromID)
        {
            try
            {
                 var letovi = await Context.Letovi.Where(p => p.Aerodrom.ID == aerodromID).ToListAsync();
                if(letovi!= null)
                {
                    return Ok(letovi);
                }
                else
                {
                    return Ok("Ne postoji ni jedan");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

        }
        [Route("DodajLet/{AerodromID}/{BrojMesta}/{KlasaID}/{DatumLeta}/{VremePolaska}/{VremeDolaska}")]
        [HttpPost]        
        public async Task<ActionResult> DodajLet(int AerodromID,int BrojMesta,int KlasaID,string DatumLeta,string VremePolaska,string VremeDolaska)
        {
            try
            {
                var letovi = await Context.Letovi.Where(p=> p.VremePolaska == VremePolaska && p.Aerodrom.ID == AerodromID).FirstOrDefaultAsync();
                
                
                if(letovi == null)
                {
                    Let let = new Let();
                    
                    var aerodrom = await Context.Aerodromi.Where(p=>p.ID == AerodromID).FirstOrDefaultAsync();
                    var klasa = await Context.Klase.Where(p=>p.ID == KlasaID).FirstOrDefaultAsync();
                    let.Aerodrom = aerodrom;
                    let.BrojMesta = BrojMesta;
                    let.DatumLeta = DatumLeta;
                    let.VremePolaska = VremePolaska;
                    let.VremeDolaska = VremeDolaska;
                    let.Klasa = klasa;
                    
                    
                    Context.Letovi.Add(let);
                    await Context.SaveChangesAsync();
                    return Ok("Dodat");
                
                }
                else
                {
                    return BadRequest("vec postoji");
                }                
            }
             catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("IzmeniLet/{letID}")]
        [HttpPut]  
        public async Task<ActionResult> PromeniLet(int letID)
        {
            try
            {
                var let = await Context.Letovi.Where(p=> p.ID == letID).FirstOrDefaultAsync();
                
                
                if(let != null)
                {
                    let.BrojMesta--;
                    
                    await Context.SaveChangesAsync();
                    return Ok("Promenjen");
                
                }
                else
                {
                    return BadRequest("Nije pronadjen");
                }                
            }

            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisiLet/{letID}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiLet(int letID)
        {
            try
            {
                
                var let = await Context.Letovi.FindAsync(letID);
                if(let!=null)
                {
                    Context.Letovi.Remove(let);
                    await Context.SaveChangesAsync();
                    return Ok("Izbrisan");   
                }
                else
                {
                    return BadRequest("Ne postoji");

                }
                
            }

            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
    }
}