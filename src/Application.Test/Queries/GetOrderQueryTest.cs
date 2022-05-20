using Xunit;
using Moq;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Application.Interfaces.Persistence;
using MorgenBooster.Application.Queries;

namespace MorgenBooster.Application.Test.Queries
{
	public class GetOrderQueryTest
	{

		private readonly Mock<IRepository<Order, int>> _orderRepository = new();
		[Fact]
		public void HappyPath()
		{
			var mockOrder = new Order()
			{
				Id = 1
			};

			_orderRepository.Setup(c => c.GetById(It.IsAny<int>())).Returns(mockOrder);

			var getOrderByIdQuery = new GetOrderQueryHandler(_orderRepository.Object);

			var result = getOrderByIdQuery.Handle(mockOrder.Id);

			_orderRepository.Verify(c => c.GetById(It.Is<int>(i => i == mockOrder.Id)), Times.Once);

			Assert.Equal(mockOrder, result);
		}
	}
}