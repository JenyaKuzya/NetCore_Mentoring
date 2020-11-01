using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetCore_Mentoring.BLL.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Category name must be between 5 and 100 characters long.")]
        public string CategoryName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Category description must be at least 5 characters long.")]
        public string Description { get; set; }
    }
}
