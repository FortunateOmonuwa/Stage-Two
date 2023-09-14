using AutoMapper;
using BackendStageTwo.Models;

namespace BackendStageTwo.DataAccess.DTO
{
    public class MappingProfiles  : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserCreateDTO, User>().ReverseMap();
        }
    }
}
