using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order:EntityBase
    {
        public Order()
        {

        }
 

        public OrderProduct OrderProduct { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime PaymentDate { get; set; }
    }
}
