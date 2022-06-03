using FamilySelection.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Validator.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Campo Nome é obrigatório!");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Campo Salário é obrigatório e tem que ser maior do que '0'!");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Campo Idade é obrigatório!");
        }
    }
}
