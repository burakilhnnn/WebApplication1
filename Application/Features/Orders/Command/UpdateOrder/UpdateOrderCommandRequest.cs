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
        public List<int> ProductId { get; set; }
    }

}
