namespace MorgenBooster.Domain.Entities
{
	public class OrderItem : BaseEntity
	{
		public string ItemName { get; set; } = string.Empty;
		public double Price { get; set; } = 0;
		public int Quantity { get; set; } = 0;
	}
}
