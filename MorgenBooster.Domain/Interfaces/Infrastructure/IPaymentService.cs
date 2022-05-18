using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Domain.Interfaces.Infrastructure;

public interface IPaymentService
{
    Task<Order> Process(Order order);
}