using AutoMapper;
using System.Linq;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserCore>();
            CreateMap<Login,LoginCore > ();
            CreateMap<LoginCore, Login>();
 
            CreateMap<BiddingCore, Bidding>();
            CreateMap<TenderCore, Tender>();
        }
    }
}
