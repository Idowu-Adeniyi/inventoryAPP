using System.ComponentModel.DataAnnotations;
namespace ProjectAPP.Models
{
    public class Category
    {
        // Make sure the category is registred with a PK
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Item>? Items { get; set; } // Navigation property for the one-to-many relationship
    }
}
