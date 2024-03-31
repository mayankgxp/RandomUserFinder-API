using AutoMapper;
using RandomUserFinder.Models;

namespace RandomUserFinder.ClientModels;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<RandomUser, RandomUserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Results.First().Name.First))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Results.First().Name.Last))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Results.First().Email))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Results.First().Picture.Large))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Results.First().Gender));
    }
}
