using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;

using static Application.Features.Orders.Queries.GetOrderById.GetOrderByIdHandler;

namespace Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdHandler :IRequestHandler<GetOrderByIdRequest,List<GetOrderByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetOrderByIdResponse>> Handle(GetOrderByIdRequest request,CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync(request.Id);

            return orders.Select(x => new GetOrderByIdResponse
            {
                Id = x.Id,
                OrderProduct = x.OrderProduct,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                PaymentDate = x.PaymentDate
            }).ToList();
        }

        public class GetOrderByIdRequest : IRequest<List<GetOrderByIdResponse>>
        {
            public int Id { get; set; }
        }

        public class GetOrderByIdResponse
        {
            public int Id { get; set; }
            public OrderProduct OrderProduct { get; set; }
            public string UserId { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;
            public DateTime PaymentDate { get; set; }

        }

    }
}
