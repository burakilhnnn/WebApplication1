
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.Orders.Command.CreateOrder
    {
        public class CreateOrderCommandRequest : IRequest<Unit>
        {
            public OrderProduct OrderProduct { get; set; }
            public string UserId { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;
            public DateTime PaymentDate { get; set; }
        }
    }
