using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Application.Interfaces.Infrastructure;

public interface IPaymentService
{
    Task<bool> Process(Order order);
}