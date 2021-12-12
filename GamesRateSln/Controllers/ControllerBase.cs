﻿// <copyright file="ControllerBase.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using AutoMapper;
using AutoMapper.QueryableExtensions;
using GamesRateSln.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRateSln.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase(ILogger logger, AppDataContext cx, IMapper mapper)
        {
            this.Context = cx;
            this.Mapper = mapper;
            this.Logger = logger;
        }

        protected AppDataContext Context { get; set; }

        protected ILogger Logger { get; set; }

        protected IMapper Mapper { get; set; }

        protected TDestination Map<TDestination>(object value)
        {
            return this.Mapper.Map<TDestination>(value);
        }

        protected void MapFrom<TDesination>(TDesination dest, object src)
        {
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }

            if (src == null)
            {
                throw new ArgumentNullException("src");
            }

            this.Mapper.Map(src, dest, src.GetType(), typeof(TDesination));
        }

        protected async Task<List<TDestination>> Project<TDestination>(IQueryable source)
        {
            var result = await source.ProjectTo<TDestination>(this.Mapper.ConfigurationProvider, source)
                .ToListAsync().ConfigureAwait(false);

            return result;
        }
    }
}
