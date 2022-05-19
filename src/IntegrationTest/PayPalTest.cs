using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Infrastructure.PaymentService;
using Xunit;

namespace MorgenBooster.IntegrationTest;

public class PayPalTest
{
    [Fact]
    public async Task PayOrder()
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddHttpClient();
        serviceCollection.AddSingleton<PayPalService>();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        PayPalService sut = serviceProvider.GetRequiredService<PayPalService>();

        Order order = new Order();
        Order paidOrder = await sut.Process(order);

        Assert.Equal(OrderStatus.Paid, paidOrder.Status);
    }
    
}