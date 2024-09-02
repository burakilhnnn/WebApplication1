using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandRequest : IRequest<Unit>
    {
        public string FullName { get; set; }
      //  public string RefreshToken { get; set; }
     //   public DateTime RefreshTokenExpiryTime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      //  public IList<Guid> RolesId { get; set; }  // IList veya List yerine ICollection kullanabilirsiniz
    }
}
