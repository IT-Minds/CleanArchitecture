using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;

namespace MorgenBooster.Infrastructure.Gmail
{
	public class GmailService : IMailService
	{
		public Task SendMail(MailMessage message)
		{
			throw new NotImplementedException();
		}
	}
}
