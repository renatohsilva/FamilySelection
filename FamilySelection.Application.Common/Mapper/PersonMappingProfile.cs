using AutoMapper;
using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Mapper
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonDto>();

            CreateMap<PersonDto, Person>();
        }
    }
}
