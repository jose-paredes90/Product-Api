using System.ComponentModel.DataAnnotations;

namespace Product_Api.Application.Dtos
{
    public class CreateProductRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
    }
}
