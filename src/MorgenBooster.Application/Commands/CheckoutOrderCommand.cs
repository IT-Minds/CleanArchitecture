namespace MorgenBooster.Application.Commands;

public class CheckoutOrderCommand
{
    public CheckoutOrderCommand(int cartId)
    {
        CartId = cartId;
    }
    public int CartId { get; set; }
}