using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Categories.Command.DeleteCategory.DeleteCategoryHandler;

namespace Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.GetReadRepository<Category>().GetByIdAsync(request.Id, cancellationToken);

            // Silme işlemi
            _unitOfWork.GetWriteRepository<Category>().Delete(category);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        public class DeleteCategoryRequest : IRequest<Unit>
        {
            public int Id { get; set; }
        }

    }
}
