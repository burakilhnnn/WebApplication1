using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<Unit>
    {
        public int ParentId { get; set; }
        public string Name { get; set; }

    }
}
