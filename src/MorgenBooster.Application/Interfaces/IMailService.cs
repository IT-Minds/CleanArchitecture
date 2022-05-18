using MorgenBooster.Domain.Entities;

namespace MorgenBooster.Application.Interfaces
{
	public interface IMailService
	{
		Task SendMail(MailMessage message);
	}
}
