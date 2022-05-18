using MorgenBooster.Application.Commands.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;
using MorgenBooster.Domain.Interfaces.Persistence;

namespace MorgenBooster.Application.Commands
{
	public class CheckoutOrderCommand : ICommand<Order, Task>
	{
		private readonly IRepository<Order, int> _repository;
		private readonly IMailService _mailService;
		public CheckoutOrderCommand(IRepository<Order, int> repository, IMailService mailService)
		{
			_repository = repository;
			_mailService = mailService;
		}
		public async Task Execute(Order input)
		{
			try
			{
				var saveResult = _repository.Add(input);
				if (saveResult)
				{
					var mailMessage = new MailMessage()
					{
						// FILL DATA
					};

					await _mailService.SendMail(mailMessage);
				}
				else
				{
					// LOG SHIT SEND MAIL CRASH EXPLODE IDK
				}
			}
			catch (Exception)
			{
				// LOG SHIT SEND MAIL CRASH EXPLODE IDK
				throw;
			}
		}
	}
}
