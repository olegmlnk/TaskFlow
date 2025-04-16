using TaskFlow.DataAccess.Entities;
using AutoMapper;
using TaskFlow.Core.Models;

namespace TaskFlow.DataAccess.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() {

        CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
