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
    public class FamilyMappingProfile : Profile
    {
        public FamilyMappingProfile()
        {
            CreateMap<Family, FamilyDto>();

            CreateMap<FamilyDto, Family>();
        }
    }
}
