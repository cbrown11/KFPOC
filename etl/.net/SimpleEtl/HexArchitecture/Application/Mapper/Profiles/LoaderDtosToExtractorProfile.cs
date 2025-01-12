using AutoMapper;
using simpleEtl.Application.Models.Extractor.Dtos;

namespace simpleEtl.Application.Automapper.Profiles
{
    public class LoaderDtosToExtractorProfile: Profile
    {
        public LoaderDtosToExtractorProfile()
        {
               // Will automatically map names if they are the same
                CreateMap<ResearchObject, Models.Loader.Dtos.Asset>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(o=> o.Id > 1? "Property": "Land"));
        }
    }
}