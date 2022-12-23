using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}