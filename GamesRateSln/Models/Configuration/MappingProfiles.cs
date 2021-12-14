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
                .ForMember(dest => dest.Year, act => act.MapFrom(src => src.ReleaseDate.Year.ToString()))
                .ForMember(dest => dest.RateCount, act => act.MapFrom(src => src.Rates.Count))
                .ForMember(dest => dest.AvrRate, act =>
                            act.MapFrom(src => src.Rates.Select(x => x.Value).Sum() / (src.Rates.Count == 0 ? 1 : src.Rates.Count)));

            this.CreateMap<Person, PersonModel>(MemberList.Destination);

            this.CreateMap<Rate, RateModel>(MemberList.Destination);

            this.CreateMap<GameModel, Game>(MemberList.Source);

            this.CreateMap<PersonModel, Person>(MemberList.Source);

            this.CreateMap<RateModel, Rate>(MemberList.Source);

            this.CreateMap<Game, AddRateModel>(MemberList.Destination)
                .ForMember(dest => dest.GameYear, act => act.MapFrom(src => src.ReleaseDate.Year.ToString()))
                .ForMember(dest => dest.GameId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.GameTitle, act => act.MapFrom(src => src.Title))
                .ForAllOtherMembers(dest => dest.Ignore());

            this.CreateMap<Rate, RecentRateModel>(MemberList.Destination)
                .ForMember(dest => dest.GameTitle, act => act.MapFrom(src => src.Game.Title))
                .ForMember(dest => dest.PersonName, act => act.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.PersonEmail, act => act.MapFrom(src => src.Person.Email))
                .ForMember(dest => dest.Comment, act => act.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value))
                .ForAllOtherMembers(dest => dest.Ignore());

            this.CreateMap<AddRateModel, Person>(MemberList.Source)
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.PersonEmail))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.PersonName))
                .ForAllOtherMembers(dest => dest.Ignore());

            this.CreateMap<AddRateModel, Rate>(MemberList.Source)
                .ForMember(dest => dest.Comment, act => act.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value))
                .ForAllOtherMembers(dest => dest.Ignore());
        }
    }
}
