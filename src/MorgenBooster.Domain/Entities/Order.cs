using Microsoft.VisualBasic;

namespace MorgenBooster.Domain.Entities
{
	public enum OrderStatus
	{
		Open,
		Paid
	}
	
	public class Order : BaseEntity
	{
		public OrderStatus Status { get; set; } = OrderStatus.Open;
	}


}
