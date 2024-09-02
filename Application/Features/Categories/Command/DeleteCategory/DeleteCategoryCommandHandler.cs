using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.GetReadRepository<Category>().GetByIdAsync(request.Id, cancellationToken);

            // Silme işlemi
            _unitOfWork.GetWriteRepository<Category>().Delete(category);

            // Değişiklikleri veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
