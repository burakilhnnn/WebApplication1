﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
