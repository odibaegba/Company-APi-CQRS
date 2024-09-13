using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands
{
    public sealed record CreateCompanyCommand (CompanyForCreationDto company) : IRequest<CompanyDto>;
   
}