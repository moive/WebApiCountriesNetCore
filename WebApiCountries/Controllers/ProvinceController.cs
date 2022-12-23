using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApiCountries.Models;

namespace WebApiCountries.Controllers
{
    [Produces("application/json")]
    [Route("api/Country/{CountryId}/Province")]
    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProvinceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Province> GetAll(int CountryId)
        {
            return context.Provinces.Where(x => x.CountryId == CountryId).ToList();
        }

        [HttpGet("{id}", Name = "provinceById")]
        public IActionResult GetById(int id)
        {
            var province = context.Provinces.FirstOrDefault(x => x.Id == id);

            if (province == null) return NotFound();

            return new ObjectResult(province);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Province province, int CountryId)
        {
            province.CountryId = CountryId;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Provinces.Add(province);
            context.SaveChanges();

            return new CreatedAtRouteResult("provinceById", new { id = province.Id }, province);
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Province province, int id)
        {
            if (province.Id != id) return BadRequest();

            context.Entry(province).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(province);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var province = context.Provinces.FirstOrDefault(x => x.Id == id);

            if (province == null) return NotFound();

            context.Provinces.Remove(province);
            context.SaveChanges();
            return Ok(province);
        }
    }
}
