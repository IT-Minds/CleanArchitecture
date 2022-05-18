using MorgenBooster.Application.Commands.Interfaces;
using MorgenBooster.Application.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;
using MorgenBooster.Domain.Interfaces.Persistence;

namespace MorgenBooster.Application.Commands
{
	public class CheckoutOrderCommandHandler : ICommand<CheckoutOrderCommand, Task>
	{
		private readonly IRepository<Cart, int> _cartRepository;
		private readonly IRepository<Order, int> _orderRepository;
		private readonly IMailService _mailService;
		private readonly IPaymentService _paymentService;
		public CheckoutOrderCommandHandler(IMailService mailService, IRepository<Order, int> orderRepository, IRepository<Cart, int> cartRepository, IPaymentService paymentService)
		{
			_mailService = mailService;
			_orderRepository = orderRepository;
			_cartRepository = cartRepository;
			_paymentService = paymentService;
		}
		public async Task Execute(CheckoutOrderCommand input)
		{
			try
			{
				var cart = _cartRepository.GetById(input.CartId);
				var order = cart.Checkout(_paymentService);
				
				var saveResult = _orderRepository.Add(order);
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
