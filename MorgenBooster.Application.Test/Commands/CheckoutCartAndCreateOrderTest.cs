using System.Threading.Tasks;
using Xunit;
using Moq;
using MorgenBooster.Application.Commands;
using MorgenBooster.Application.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Infrastructure;
using MorgenBooster.Domain.Interfaces.Persistence;

namespace MorgenBooster.Application.Test.Commands
{
	public class CheckoutCartAndCreateOrderTest
	{
		private readonly Mock<IPaymentService> _paymentService = new();
		private readonly Mock<IMailService> _mailService = new();
		private readonly Mock<IRepository<Order, int>> _orderRepository = new();
		private readonly Mock<IRepository<Cart, int>> _cartRepository = new();

		[Fact]
		public async Task HappyPath()
		{
			// Arrange
			Cart cart = new Cart();
			cart.AddItem(new Product());
			_cartRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(cart);

			var checkoutCommand = new CheckoutOrderCommand(cart.Id);
			var sut = new CheckoutOrderCommandHandler(_mailService.Object, _orderRepository.Object, _cartRepository.Object, _paymentService.Object);

			// Act
			await sut.Execute(checkoutCommand);
			
			// Assert
			_orderRepository.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
		}
	}
}