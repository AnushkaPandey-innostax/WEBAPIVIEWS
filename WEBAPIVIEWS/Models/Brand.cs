using System.ComponentModel.DataAnnotations;

namespace WEBAPIVIEWS.Models
{
    public class Brand
    {
     
            public int id { get; set; }
        [Required]
            public string name { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public int isActive { get; set; }

        }
    }

