﻿using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Categories.Command.CreateCategory.CreateCategoryHandler;

namespace Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category(request.Name, request.ParentId);

            await _unitOfWork.GetWriteRepository<Category>().AddAsync(category, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            // MediatR için boş döndürme
            return Unit.Value;

        }

    
        public class CreateCategoryRequest : IRequest<Unit>
        {
            public int ParentId { get; set; }
            public string Name { get; set; }

        }
    }



}

