using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [Required]
        [DisplayName("Stock")]
        public string Image{ get; set; }

        [Required]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }
    }
}
