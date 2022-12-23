using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCountries.Models;

namespace WebApiCountries.Controllers
{
    [Produces("application/json")]
    [Route("api/Country")]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CountryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return context.Countries.ToList();
        }

        [HttpGet("{id}", Name = "countryCreated")]
        public IActionResult GetById(int id)
        {
            var country = context.Countries.Include(x => x.Provinces).FirstOrDefault(x => x.Id == id);

            if (country == null) return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                context.Countries.Add(country);
                context.SaveChanges();
                return new CreatedAtRouteResult("countryCreated", new { id = country.Id }, country);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Country country, int id)
        {
            if (country.Id != id) return BadRequest();

            context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = context.Countries.FirstOrDefault(x => x.Id == id);

            if (country == null) return NotFound();

            context.Countries.Remove(country);
            context.SaveChanges();
            return Ok(country);
        }
    }
}
