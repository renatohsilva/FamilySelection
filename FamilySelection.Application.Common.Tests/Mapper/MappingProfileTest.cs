using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Tests.Mapper
{
    public abstract class MappingProfileTest<TProfile> where TProfile : Profile, new()
    {
        protected readonly IMapper mapper;

        public MappingProfileTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}