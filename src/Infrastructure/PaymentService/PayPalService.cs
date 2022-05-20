using MorgenBooster.Domain.Entities;
using MorgenBooster.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;

namespace MorgenBooster.Infrastructure.PaymentService
{

    public class PayPalService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PayPalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> Process(Order order)
        {
            var result = false;

            // Do api magic. using http client

            return Task.FromResult(result);
        }
    }
}