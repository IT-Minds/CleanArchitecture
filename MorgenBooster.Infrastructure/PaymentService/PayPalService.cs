using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;

namespace MorgenBooster.Infrastructure.PaymentService;

public class PayPalService : IPaymentService
{

    public Task<Order> PayOrder(Order order)
    {
        // Do api magic.
        order.Status = OrderStatus.Paid;
        return Task.FromResult(order);
    }
}