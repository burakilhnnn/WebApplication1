using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using static Application.Features.Orders.Queries.GetAllOrders.GetAllOrderHandler.Handler;


namespace Application.Features.Orders.Queries.GetAllOrders
{

    public record GetAllOrderHandler(GetAllOrderRequest Request) : IRequest<List<GetAllOrderResponse>>
    {
        public class Handler : IRequestHandler<GetAllOrderHandler, List<GetAllOrderResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllOrderResponse>> Handle(GetAllOrderHandler query, CancellationToken cancellationToken)
            {
                var orders = await _unitOfWork.Orders.GetAllOrdersAsync(query.Request.Id, query.Request.UserId, query.Request.OrderDate, query.Request.PaymentDate);

                var response = orders.Select(x => new GetAllOrderResponse
                {
                    Id = x.Id,
                    OrderProduct = x.OrderProduct,
                    UserId = x.UserId,
                    OrderDate = x.OrderDate,
                    PaymentDate = x.PaymentDate
                })
                .ToList();

                return response;
            }

            public class GetAllOrderResponse
            {
                public int Id { get; set; }
                public OrderProduct OrderProduct { get; set; }
                public string UserId { get; set; }
                public DateTime OrderDate { get; set; } = DateTime.UtcNow;
                public DateTime PaymentDate { get; set; }



            }

            public class GetAllOrderRequest
            {
                public int? Id { get; set; }
                public string? UserId { get; set; }
                public DateTime? OrderDate { get; set; }
                public DateTime? PaymentDate { get; set; }


                public GetAllOrderHandler ToQuery()
                {
                    return new GetAllOrderHandler(this);
                }
            }

        }
    }
}


    
