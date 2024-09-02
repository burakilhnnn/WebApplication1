using MediatR;

namespace WebApplication1.Controllers
{
    public class UpdateUserCommandRequest : IRequest<Unit>
    {

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}