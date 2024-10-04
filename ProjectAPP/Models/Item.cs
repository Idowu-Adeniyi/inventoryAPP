using System.ComponentModel.DataAnnotations;
namespace ProjectAPP.Models
{
    
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        //public int Quantity { get; set; }
        public int Quantity { get; set; }

        // Foreign Keys and Navigation Properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        //public Category Category { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        //public Supplier Supplier { get; set; }
    }
    
}
