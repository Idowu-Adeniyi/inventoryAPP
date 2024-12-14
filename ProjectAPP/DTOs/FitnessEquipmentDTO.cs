namespace ProjectAPP.DTOs
{
    public class FitnessEquipmentDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty; // Ensure non-nullable default
        public int Quantity { get; set; }
        public string Category { get; set; } = string.Empty; // Ensure non-nullable default
        public string Supplier { get; set; } = string.Empty; // Ensure non-nullable default
    }
}
