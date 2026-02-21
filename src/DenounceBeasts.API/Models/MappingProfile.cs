using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models.Dtos;

namespace DenounceBeasts.API.Models
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Status, StatusDto>().ReverseMap();
            //CreateMap<StatusDto, Status>();

            CreateMap<Sector, SectorDto>()
               // .ForMember(dest => dest.MyPropertyForTest, opt => opt.MapFrom(src => src.MyPropertyForTestInDeb))
               // .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality))
                .ReverseMap()
              //  .ForMember(dest => dest.MyPropertyForTestInDeb, opt => opt.MapFrom(src => src.MyPropertyForTest))
                //.ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality))
                ;

            //CreateMap<Sector, SectorDto>()
            //.ForMember(dest => dest.MyPropertyForTest, opt => opt.MapFrom(src => src.MyPropertyForTestInDeb))
            //// .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality))
            //     ; 

            //CreateMap<SectorDto, Sector>()
            //  .ForMember(dest => dest.MyPropertyForTestInDeb, opt => opt.MapFrom(src => src.MyPropertyForTest))
            //  //.ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality))
            //  ;
             
            CreateMap<Sector, SectorCreateDto>().ReverseMap(); 
            CreateMap<Sector, SectorUpdateDto>().ReverseMap();

            CreateMap<Municipality, MunicipalityDto>().ReverseMap();
            CreateMap<ComplaintType, ComplaintTypeDto>().ReverseMap();

        }
    }
}
