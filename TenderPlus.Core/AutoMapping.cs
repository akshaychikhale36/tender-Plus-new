using AutoMapper;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            
            CreateMap<Login, LoginCore>();
            CreateMap<LoginCore, Login>();

            CreateMap<BiddingCore, Bidding>();
            CreateMap<Bidding, BiddingCore>();

            CreateMap<TenderCore, Tender>();
            CreateMap<Tender, TenderCore>();


            CreateMap<TenderUsers, TenderUsersCore>();
            CreateMap<TenderUsersCore, TenderUsers>();

            CreateMap<User, UserCore>();
            CreateMap<UserCore, User>();
        }
    }
}
