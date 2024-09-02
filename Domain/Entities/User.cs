using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Roles = new List<Guid>(); // Varsayılan bir boş liste oluşturuyoruz
        }

        public User(string fullName,/* string refreshToken, DateTime refreshTokenExpiryTime,*/ string email, string password/* ,List<Guid> roles*/)
        {
            FullName = fullName;
          //  RefreshToken = refreshToken;
           // RefreshTokenExpiryTime = refreshTokenExpiryTime;
            Email = email;
            Password = password;
         //   Roles = roles ?? new List<Guid>(); // Eğer null ise boş bir liste oluşturuyoruz
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
