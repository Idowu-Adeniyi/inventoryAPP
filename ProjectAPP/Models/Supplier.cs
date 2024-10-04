using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPP.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierInfo { get; set; }
        public ICollection<Item>? Items { get; set; } // Navigation property for the one-to-many relationship
    }
}
