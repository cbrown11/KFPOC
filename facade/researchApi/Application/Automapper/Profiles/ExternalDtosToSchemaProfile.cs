

using AutoMapper;
using researchApi.Application.Models.External.Dtos;

namespace researchApi.Application.Automapper.Profiles
{
    public class ExternalDtosToSchemaProfile: Profile
    {
        public ExternalDtosToSchemaProfile()
        {
               // Will automatically map names if they are the same
                CreateMap<ResearchObject, Schema.Asset>()
                    .ForMember(dest => dest.AnotherName, opt => opt.MapFrom(src => $"Another Name with {src.Name}"))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(o=> o.Id > 1? "Property": "Land"));
        }
    }
}