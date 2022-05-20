using MorgenBooster.Application.Commands.Interfaces;
using MorgenBooster.Domain.Entities;
using MorgenBooster.Application.Interfaces.Infrastructure;
using MorgenBooster.Application.Interfaces.Persistence;

namespace MorgenBooster.Application.Commands
{
    public class CheckoutOrderCommandHandler : ICommandHandler<CheckoutOrderCommand, Task>
    {
        private readonly IRepository<Cart, int> _cartRepository;
        private readonly IRepository<Order, int> _orderRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly IMailService _mailService;
        private readonly IPaymentService _paymentService;
        public CheckoutOrderCommandHandler(IMailService mailService, IPaymentService paymentService, IRepository<Order, int> orderRepository, IRepository<User, int> userRepository, IRepository<Cart, int> cartRepository)
        {
            _mailService = mailService;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _paymentService = paymentService;
        }
        public async Task Handle(CheckoutOrderCommand input)
        {
            try
            {
                var cart = _cartRepository.GetById(input.CartId);

                var user = _userRepository.GetById(input.UserId);

                var order = new Order()
                {
                    User = user, 
                    Status = OrderStatus.Pending
                };

                var distinctProducts = cart.Products.DistinctBy(p => p.Id);

                foreach (var product in distinctProducts)
                {
                    order.OrderItems.Add(new OrderItem()
                    {
                        ItemName = product.Name,
                        Price = product.Price,
                        Quantity = cart.Products.Where(p => p.Id == product.Id).Count()
                    });
                }

                var result = await _paymentService.Process(order);

                if (result)
                {
                    order.Status = OrderStatus.Paid;
                }
                else
                {
                    //Keep order in pending and retry or  LOG SHIT SEND MAIL CRASH EXPLODE IDK
                }

                var saveResult = _orderRepository.Add(order);


                if (saveResult)
                {
                    var mailMessage = new MailMessage()
                    {
                        Subject = $"Order confirmed",
                        Message = $"Hello {user.Name} your order is placed and is being shipped ASAP!"
                    };

                    mailMessage.Receipients.Add(user.Email);

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
