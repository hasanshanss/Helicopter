using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helicopter.DAL.Entities;
using Helicopter.API.Contracts.V1.Requests;
using Helicopter.API.Contracts.V1.Responses;

namespace Helicopter.API.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<CreateGameRequest, Game>();
            CreateMap<Game, DownloadGameResponse>();
            //CreateMap<Game, CreateGameRequest>();
        }
    }
}
