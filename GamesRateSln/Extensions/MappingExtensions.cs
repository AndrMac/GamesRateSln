// <copyright file="MappingExtensions.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRateSln.Extensions
{
    public static class MappingExtensions
    {
        public static async Task<ICollection<TDest>> Project<TDest>(this IQueryable source, IMapper mapper)
        {
            return await mapper.ProjectTo<TDest>(source).ToListAsync();
        }

        public static TDest To<TDest>(this object source, IMapper mapper)
        {
            return mapper.Map<TDest>(source);
        }
    }
}
