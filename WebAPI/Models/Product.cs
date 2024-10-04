using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40, ErrorMessage = "Product Name cannot be longer than 40 characters")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public string QuantityPerUnit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Unit Price must be a non-negative number")]
        public decimal UnitPrice { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Units In Stock must be a non-negative number")]
        public short UnitsInStock { get; set; }

        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
