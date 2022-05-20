namespace MorgenBooster.Application.Commands
{
    public class CheckoutOrderCommand
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}