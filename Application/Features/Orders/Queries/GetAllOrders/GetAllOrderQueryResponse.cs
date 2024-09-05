using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderQueryResponse
    {
        public int Id { get; set; }
        public OrderProduct OrderProduct { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime PaymentDate { get; set; }



    }
}
