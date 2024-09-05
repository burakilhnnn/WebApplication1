using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.UpdateOrder
{
    public class UpdateOrderCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public OrderProduct OrderProduct { get; set; }
        public string USerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime PaymentDate { get; set; }
    }

}
