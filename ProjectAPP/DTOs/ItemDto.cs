using System.ComponentModel.DataAnnotations;

namespace ProjectAPP.DTOs
{
    public class ItemDto
    {
        public int ItemId { get; set; }

        [Required] // Ensure this field is required
        public string ItemName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }
    }
}
