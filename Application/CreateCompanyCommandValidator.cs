using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using FluentValidation;

namespace Application
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.company.Name).NotEmpty().MaximumLength(60);
            RuleFor(x => x.company.Address).NotEmpty().MaximumLength(60);
        }
    }
}