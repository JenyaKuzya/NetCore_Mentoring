using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetCore_Mentoring.BLL.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Product name must be between 5 and 100 characters long.")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [DisplayName("Supplier")]
        public int SupplierID { get; set; }

        [DisplayName("Quantity")]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 1000000,
            ErrorMessage = "Price must be between 0 and 1000000.")]
        [DisplayName("Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("In Stock")]
        [Range(0, 99)]
        public short UnitsInStock { get; set; }

        [DisplayName("On Order")]
        [Range(0, 99)]
        public short UnitsOnOrder { get; set; }

        [DisplayName("Reorder Level")]
        [Range(0, 99)]
        public short ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
