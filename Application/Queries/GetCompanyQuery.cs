using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries
{
    public sealed record GetCompanyQuery(Guid CompanyId, bool TrackChanges) : IRequest<CompanyDto>;
   
}