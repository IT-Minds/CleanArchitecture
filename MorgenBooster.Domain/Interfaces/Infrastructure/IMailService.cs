using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Domain.Interfaces.Infrastructure
{
	public interface IMailService
	{
		Task SendMail(MailMessage message);
	}
}
