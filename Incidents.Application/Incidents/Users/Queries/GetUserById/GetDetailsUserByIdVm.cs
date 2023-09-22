﻿using AutoMapper;
using Incidents.Application.Common.Mappings;
using Incidents.Domain.Entities;

namespace Incidents.Application.Incidents.Queries.UserQueries.GetUserById
{
    public class GetDetailsUserByIdVm : IMapWith<User>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetDetailsUserByIdVm>();
                //.ForMember(x => x.UserName, option => option.MapFrom(x => x.UserName))
                //.ForMember(x => x.FullName, option => option.MapFrom(x => x.FullName))
                //.ForMember(x => x.Email, option => option.MapFrom(x => x.Email))
                //.ForMember(x => x.IsEnabled, option => option.MapFrom(x => x.IsEnabled));
        }
    }
}