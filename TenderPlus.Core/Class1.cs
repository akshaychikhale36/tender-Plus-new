using AutoMapper;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, User>(); // means you want to map from User to UserDTO
        }
    }
}
