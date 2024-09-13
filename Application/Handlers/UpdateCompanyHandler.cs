using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers
{
    internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _repository.Company.GetCompanyAsync(request.companyId,  request.trackChanges);
            if (companyEntity is null)
            throw new CompanyNotFoundException(request.companyId);

           _mapper.Map(request.CompanyForUpdateDto, companyEntity);
           await _repository.SaveAsync();
        }
    }
}