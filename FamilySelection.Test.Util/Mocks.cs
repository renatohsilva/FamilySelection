using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;

namespace FamilySelection.Test.Util
{
    public class Mocks
    {
        public Family CreateMockFamily()
        {
            return new Family()
            {
                Code = RandomInt(),
                Description = $"Descrição {RandomInt()}"
            };
        }

        public FamilyDto CreateMockFamilyDto()
        {
            return new FamilyDto()
            {
                Code = RandomInt(),
                Description = $"Descrição {RandomInt()}"
            };
        }

        public Person CreateMockPerson()
        {
            return new Person()
            {
                Name = $"Nome {RandomInt()}",
                Age = RandomInt(),
                Salary = RandomInt()
            };
        }

        public PersonDto CreateMockPersonDto()
        {
            return new PersonDto()
            {
                Name = $"Nome {RandomInt()}",
                Age = RandomInt(),
                Salary = RandomInt()
            };
        }

        private int RandomInt()
        {
            Random rnd = new Random();
            return rnd.Next(1, 1000);
        }

    }
}