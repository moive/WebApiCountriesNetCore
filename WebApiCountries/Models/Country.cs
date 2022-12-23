using System.ComponentModel.DataAnnotations;

namespace WebApiCountries.Models
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
    }
}
