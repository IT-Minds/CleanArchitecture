namespace MorgenBooster.Domain.Entities
{

    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}