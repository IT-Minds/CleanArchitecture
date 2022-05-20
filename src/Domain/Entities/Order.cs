namespace MorgenBooster.Domain.Entities
{
	public class Order : BaseEntity
	{
		public User User { get; set; } = new User();
		public OrderStatus Status { get; set; } = OrderStatus.Pending;
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}


}
