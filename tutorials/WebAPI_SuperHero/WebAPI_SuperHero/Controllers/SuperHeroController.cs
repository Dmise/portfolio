using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private static List<SuperHero> heroes = new List<SuperHero>()
        //{
        //         new SuperHero() {
        //             Id = 1,
        //             Name = "Tsar",
        //             FirstName = "Vladimir",
        //             LastName = "Putin",
        //             Place = "Russia"
        //         },
        //         new SuperHero() {
        //             Id = 2,
        //             Name = "Tsar",
        //             FirstName = "Alexander",
        //             LastName = "Lukashenko",
        //             Place = "Belarus"
        //         }
        //};
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
           _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero != null)
                return Ok(hero);
            else
                return BadRequest("Hero not found");
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero != null)
            {
                dbHero.Name = request.Name;
                dbHero.FirstName = request.FirstName;
                dbHero.LastName = request.LastName;
                dbHero.Place = request.Place;
                await _context.SaveChangesAsync();
                return Ok(_context.SuperHeroes);
            }

            return BadRequest("Hero was not updated");

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {

            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero != null)
            {
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
                return Ok($"{hero.Name} was deleted");
            }
            return BadRequest("Hero not found");

        }
    }

}
