using MorgenBooster.Application.Interfaces.Infrastructure;
using MorgenBooster.Domain.Entities;

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
