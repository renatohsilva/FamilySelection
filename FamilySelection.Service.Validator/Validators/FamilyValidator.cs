using FamilySelection.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Validator.Validators
{
    public class FamilyValidator : AbstractValidator<Family>
    {
        public FamilyValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Campo Código é obrigatório!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Campo Descrição é obrigatório!");            
        }
    }
}
