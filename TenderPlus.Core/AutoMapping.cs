using AutoMapper;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserCore, User>();
            CreateMap<LoginCore, Login>();
            CreateMap<BiddingCore, Bidding>();
            CreateMap<TenderCore, Tender>();
        }
    }
}
