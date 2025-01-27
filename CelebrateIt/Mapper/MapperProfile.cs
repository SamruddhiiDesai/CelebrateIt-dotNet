using AutoMapper;
using CelebrateIt.DTOs.UserDTO;
using CelebrateIt.Models;

namespace CelebrateIt.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap<Users, ReqUserRegistrationDTO>().ReverseMap();
                
        }
    }
}
