namespace InnovaSystem.Core.Domain.Entities.Inventory
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; } 
        public string? ProductDescription { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
