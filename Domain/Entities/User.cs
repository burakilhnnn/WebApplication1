using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Roles = new List<Guid>();
        }

        public User(string fullName, string email, string password)
        {
            FullName = fullName;

            Email = email;
            Password = password;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; } 
        public string Password { get; set; }
        public List<Guid> Roles { get; set; } = new List<Guid> { Guid.Parse("b4d7cb70-32a9-44fa-ba7e-aec5eb5fbc4b") };
    }
}
