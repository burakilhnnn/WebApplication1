﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        /* public string PhoneNumber { get; set; }
        public string Address { get; set; }*/
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
