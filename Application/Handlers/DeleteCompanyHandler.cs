using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers
{
    internal sealed class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IRepositoryManager _repository;

        public DeleteCompanyHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
         public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.Company.GetCompanyAsync(request.companyId, request.trackChanges);
            
            if (company is null)
            throw new CompanyNotFoundException(request.companyId);
            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
        }
    }
}