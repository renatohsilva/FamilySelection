using FamilySelection.Application.Common.Mapper;
using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;
using FamilySelection.Test.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Tests.Mapper
{
    public class PersonMappingProfileTest : MappingProfileTest<PersonMappingProfile>
    {
        private readonly Mocks mocks;

        public PersonMappingProfileTest()
        {
            mocks = new Mocks();
        }

        [Test]
        public void Map_PersonParaPersonDto_HasToMap()
        {
            var entity = mocks.CreateMockPerson();
            var dto = mapper.Map<Person, PersonDto>(entity);

            Assert.That(entity.Name, Is.EqualTo(dto.Name));
            Assert.That(entity.Age, Is.EqualTo(dto.Age));
            Assert.That(entity.Salary, Is.EqualTo(dto.Salary));
        }

        [Test]
        public void Map_PersonDtoParaPerson_HasToMap()
        {
            var dto = mocks.CreateMockPersonDto();
            var entity = mapper.Map<PersonDto, Person>(dto);


            Assert.That(entity.Name, Is.EqualTo(dto.Name));
            Assert.That(entity.Age, Is.EqualTo(dto.Age));
            Assert.That(entity.Salary, Is.EqualTo(dto.Salary));
        }
    }
}
