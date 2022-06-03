using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Helper
{
    public static class MapperExtensions
    {
        public static IEnumerable<TDestination> MapList<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> source)
        {
            return mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
    }
}
