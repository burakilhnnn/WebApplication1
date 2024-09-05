using Application.Features.Orders.Queries.GetAllOrder;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;


namespace Application.Features.Orders.Queries.GetAllOrders
{

    public record GetAllOrderQueryHandler(GetAllOrdersQueryRequest Request) : IRequest<List<GetAllOrderQueryResponse>>
    {
        public class Handler : IRequestHandler<GetAllOrderQueryHandler, List<GetAllOrderQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryHandler query, CancellationToken cancellationToken)
            {
                var orders = await _unitOfWork.Orders.GetAllOrdersAsync(query.Request.Id, query.Request.UserId, query.Request.OrderDate, query.Request.PaymentDate);

                var response = orders.Select(x => new GetAllOrderQueryResponse
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

        }
    }
}


    
