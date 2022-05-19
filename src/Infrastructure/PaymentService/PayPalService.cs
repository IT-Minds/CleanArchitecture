using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;

namespace MorgenBooster.Infrastructure.PaymentService;

public class PayPalService : IPaymentService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PayPalService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public Task<Order> Process(Order order)
    {
        // Do api magic. using http client
        order.Status = OrderStatus.Paid;
        return Task.FromResult(order);
    }
}