using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CompanyForUpdateDto(string Name, string Address, string Country);
   
}