using System.ComponentModel.DataAnnotations;

namespace WEBAPIVIEWS.Models
{
    public class Brands
    {
     
            public int ID { get; set; }
        [Required]
            public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }

        }
    }

