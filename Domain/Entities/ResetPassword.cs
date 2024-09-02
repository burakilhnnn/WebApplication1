using Domain.Common;
using System;

namespace Domain.Entities
{
    public class ResetPassword
    {
        public int? Id { get; set; }
        public Guid UserId { get; set; }
        public int? Ip { get; set; }
        public string ResetCode { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; private set; }
        public DateTime? ExpiryDate { get; set; }

        public void Login()
        {
            LastModifiedDate = DateTime.Now;
        }
        public User User { get; set; }

    }
}
