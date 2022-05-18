using MorgenBooster.Domain.Interfaces.Infrastructure;

namespace MorgenBooster.Domain.Entities;

public class Cart : BaseEntity
{
    public void AddItem(Product product)
    {
        // do some logic
    }

    public Order Checkout(IPaymentService payment)
    {
        var order = new Order(); // should be from cart
        payment.Process(order);
        
        return new Order();
    }
}