
using MediatR;
using System;

namespace Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<Unit>
    {
      //  public Guid Id { get; set; } // Benzersiz rol kimliği
        public string Name { get; set; } // Rol adı
        public string Description { get; set; } // Rol açıklaması
    }
}
