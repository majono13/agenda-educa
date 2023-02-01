using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Domain.Entities;

namespace EducaApi.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserDTO, User>();

            CreateMap<UserDTO, User>();
        }
    }
}
