using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Application.Interfaces.Infrastructure
{
    public interface IMailService
    {
        Task SendMail(MailMessage message);
    }
}
