using System.ComponentModel.DataAnnotations;
namespace WEBAPIVIEWS.Models
{
        public class ProductViewModel
        {

            public int Id { get; set; }
            [Required]
            public string Name { get; set; } = null!;
            [Required]
            public double Price { get; set; }
            [Required]
            public string Category { get; set; } = null!;
            [Required]
            public IFormFile photo { get; set; } = null!;
        }

    }



