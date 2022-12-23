using System.ComponentModel.DataAnnotations;

namespace WebApiCountries.Models
{
    public class Country
    {
        public Country()
        {
            Provinces = new List<Province>();
        }

        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }
}
