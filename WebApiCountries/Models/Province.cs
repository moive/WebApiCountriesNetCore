using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiCountries.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        //[JsonIgnore]
        //public Country Country { get; set; }
    }
}
