using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetCore_Mentoring.API.Models
{
    public class ProductCreateRequest
    {
        [Required]
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Product name must be between 5 and 100 characters long.")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [Required]
        [Range(0, 1000000,
            ErrorMessage = "Price must be between 0 and 1000000.")]
        [DisplayName("Price")]
        public decimal UnitPrice { get; set; }
    }
}
