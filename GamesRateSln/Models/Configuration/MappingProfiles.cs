// <copyright file="MappingProfiles.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using AutoMapper;
using GamesRateSln.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRateSln.Models.Configuration
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            this.CreateMap<Game, GameModel>(MemberList.Destination)
                .ForMember(dest => dest.Year, act => act.MapFrom(src => src.ReleaseDate.Year.ToString()));

            this.CreateMap<Person, PersonModel>(MemberList.Destination);

            this.CreateMap<Rate, RateModel>(MemberList.Destination);

            this.CreateMap<GameModel, Game>(MemberList.Source);

            this.CreateMap<PersonModel, Person>(MemberList.Source);

            this.CreateMap<RateModel, Rate>(MemberList.Source);
        }
    }
}
