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
    public class FamilyMappingProfileTest : MappingProfileTest<FamilyMappingProfile>
    {
        private readonly Mocks mocks;

        public FamilyMappingProfileTest()
        {
            mocks = new Mocks();
        }

        [Test]
        public void Map_FamilyParaFamilyDto_HasToMap()
        {
            var entity = mocks.CreateMockFamily();
            var dto = mapper.Map<Family, FamilyDto>(entity);

            Assert.That(entity.Code, Is.EqualTo(dto.Code));
            Assert.That(entity.Description, Is.EqualTo(dto.Description));
        }

        [Test]
        public void Map_FamilyDtoParaFamily_HasToMap()
        {
            var dto = mocks.CreateMockFamilyDto();
            var entity = mapper.Map<FamilyDto, Family>(dto);

            Assert.That(entity.Code, Is.EqualTo(dto.Code));
            Assert.That(entity.Description, Is.EqualTo(dto.Description));
        }
    }
}
