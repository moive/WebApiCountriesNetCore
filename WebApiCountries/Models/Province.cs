using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCountries.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
