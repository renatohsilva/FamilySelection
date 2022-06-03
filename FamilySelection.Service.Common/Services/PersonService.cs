using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Interfaces;
using FamilySelection.Service.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services
{
    public class PersonService : GenericService<Person>, IPersonService
    {
        private readonly IValidator<Person> validatorPerson;
        public PersonService(IPersonRepository personRepository, IValidator<Person> validatorPerson) : base(personRepository)
        {
            this.validatorPerson = validatorPerson;
        }

        public override void Consistency(Person entity)
        {
            validatorPerson.ValidateAndThrow(entity);
        }
    }
}
