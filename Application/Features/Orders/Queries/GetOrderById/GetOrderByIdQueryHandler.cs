using Application.Interfaces.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler :IRequestHandler<GetOrderByIdQueryRequest,List<GetOrderByIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQueryRequest request,CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync(request.Id);

            return orders.Select(x => new GetOrderByIdQueryResponse
            {
                Id = x.Id,
                OrderProduct = x.OrderProduct,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                PaymentDate = x.PaymentDate
            }).ToList();
        }
    }
}
