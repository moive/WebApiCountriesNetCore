using Microsoft.AspNetCore.Mvc;
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
    }
}
