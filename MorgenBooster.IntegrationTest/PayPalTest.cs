using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Infrastructure.PaymentService;
using Xunit;

namespace MorgenBooster.IntegrationTest;

public class PayPalTest
{
    [Fact]
    public async Task GenerateLabelForOrder()
    {
        ServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<PayPalService>();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        PayPalService sut = serviceProvider.GetRequiredService<PayPalService>();

        Order order = new Order();
        Order paidOrder = await sut.PayOrder(order);

        Assert.Equal(OrderStatus.Paid, paidOrder.Status);
    }
    
}