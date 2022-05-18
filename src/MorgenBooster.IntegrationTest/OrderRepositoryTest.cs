using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Domain.Interfaces.Persistence;
using MorgenBooster.Persistence;
using MorgenBooster.Persistence.EntityFramework;
using Xunit;

namespace MorgenBooster.IntegrationTest;

public class OrderRepositoryTest
{
    [Fact]
    public void GetNotificationsForUser()
    {
        // This test dosen't work without migrations
        // Arrange
        var customerOrder = new Order();
        IList<Order> ordersList = new List<Order> { customerOrder };
        
        var mockContext = Create.MockedDbContextFor<ECommerceDbContext>();
        mockContext.Orders.AddRange(ordersList);
        mockContext.SaveChanges();
        

        // Act
        IRepository<Order, int> repository = new BaseRepository<Order>(mockContext);
        var notifications = repository.GetAll().ToList();
        
        // Assert
        Assert.Single(notifications);
        Assert.Equal(new List<Order> {customerOrder}, notifications);
    }
}