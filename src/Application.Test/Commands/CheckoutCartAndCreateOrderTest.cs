using System.Threading.Tasks;
using Xunit;
using Moq;
using MorgenBooster.Application.Commands;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Application.Interfaces.Infrastructure;
using MorgenBooster.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MorgenBooster.Application.Test.Commands
{
    public class CheckoutCartAndCreateOrderTest
	{
		private readonly Mock<IPaymentService> _paymentService = new();
		private readonly Mock<IMailService> _mailService = new();
		private readonly Mock<IRepository<Order, int>> _orderRepository = new();
		private readonly Mock<IRepository<Cart, int>> _cartRepository = new();
		private readonly Mock<IRepository<User, int>> _userRepository = new();


		[Fact]
		public async void HappyPath()
		{
			// Arrange
			var mockCart = new Cart()
			{
				Id = 1,
				Products = new List<Product>()
				{
					new Product()
					{
						Name = "Product 1",
						Id = 1,
						Price = 2000
					},
					new Product()
					{
						Name = "Product 1",
						Id = 1,
						Price = 2000
					},
					new Product()
					{
						Name = "Product 2",
						Id = 2,
						Price = 1000
					}
				}
			};

			var mockUser = new User()
			{
				Id = 1,
				Name = "Sammi El-Sayed",
				Email = "sap@it-minds.dk"
			};

			_cartRepository.Setup(c => c.GetById(It.IsAny<int>())).Returns(mockCart);

			_userRepository.Setup(u => u.GetById(It.IsAny<int>())).Returns(mockUser);

            _paymentService.Setup(p => p.Process(It.IsAny<Order>())).Returns(Task.FromResult(true));

            _orderRepository.Setup(o => o.Add(It.IsAny<Order>())).Returns(true);

			var checkoutCommand = new CheckoutOrderCommand()
			{
				UserId = mockUser.Id,
				CartId = mockCart.Id
			};

			var checkoutOrderCommandHandler = new CheckoutOrderCommandHandler(_mailService.Object, _paymentService.Object, _orderRepository.Object, _userRepository.Object, _cartRepository.Object);

			// Act
			 await checkoutOrderCommandHandler.Handle(checkoutCommand);

			// Assert
			_cartRepository.Verify(c => c.GetById(It.Is<int>(i => i == mockCart.Id)), Times.Once);
			_userRepository.Verify(u => u.GetById(It.Is<int>(i => i == mockUser.Id)), Times.Once);

			//verify process is called called with an order with the correct user returned from _userRepository.GetById and an order item containing the items from the cart returned from _cartRepository.GetById
			_paymentService.Verify(p => p.Process(It.Is<Order>(o => o.User.Email == mockUser.Email && o.User.Name == mockUser.Name && o.OrderItems.Where(oi => oi.ItemName == mockCart.Products[0].Name && oi.Quantity == 2 && oi.Price == mockCart.Products[0].Price).Count() == 1 && o.OrderItems.Where(oi => oi.ItemName == mockCart.Products[2].Name && oi.Price == mockCart.Products[2].Price && oi.Quantity == 1).Count() == 1)), Times.Once);

			//verify add is called with an order with status paid and the correct user returned from _userRepository.GetById and an order item containing the items from the cart returned from _cartRepository.GetById
			_orderRepository.Verify(o => o.Add(It.Is<Order>(p => p.Status == OrderStatus.Paid && p.User.Email == mockUser.Email && p.User.Name == mockUser.Name  && p.OrderItems.Where(oi => oi.ItemName == mockCart.Products[0].Name && oi.Quantity == 2 && oi.Price == mockCart.Products[0].Price).Count() == 1 && p.OrderItems.Where(oi => oi.ItemName == mockCart.Products[2].Name && oi.Price == mockCart.Products[2].Price && oi.Quantity == 1).Count() == 1)), Times.Once);
			
			//verify that an email is send containing the user as an receipient and the correct subject and message
			_mailService.Verify(m => m.SendMail(It.Is<MailMessage>(m => m.Receipients.Contains(mockUser.Email) && m.Subject == $"Order confirmed" && m.Message == $"Hello {mockUser.Name} your order is placed and is being shipped ASAP!")), Times.Once);
		}
	}
}