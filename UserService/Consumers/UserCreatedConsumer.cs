using MassTransit;
using Shared.Contracts;
using UserService.Entities;
using UserService.Services;

namespace UserService.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly IUserService _userService;

        public UserCreatedConsumer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var e = context.Message;

            var user = new User
            {
                Id = e.Id,
                Username = e.Username,
                Email = e.Email
            };

            await _userService.CreateUserAsync(user);
        }
    }
}
