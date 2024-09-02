using MediatR;

namespace WebApplication1.Controllers
{
    public class UpdateRoleCommandRequest : IRequest<Unit>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}