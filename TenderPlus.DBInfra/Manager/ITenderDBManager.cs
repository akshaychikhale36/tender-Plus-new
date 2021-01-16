﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public interface ITenderDBManager
    {
        Task<int> CreateTender(Tender tenderRequest);
        Task<bool> UpdateTender(Tender tenderRequest);
        Task<bool> CreateBidding(Bidding bidding);
        Task<bool> DeleteTender(int id);
        Task<IEnumerable<Tender>> GetTenders();
        Task<bool> UpdateBidding(Bidding biddingRequest);
      
        Task<bool> RegisterTender(TenderUsers tenderUsers);
        Task<Tender> GetRegisters(int tenderid);
        Task<IEnumerable<TenderUsers>> GetUserTenders(int userId);
        Task<IEnumerable<Tender>> getUserAssign(int userId);
        Task<Tender> getTenderBid(int tenderId);
        Task<Tender> postTenderBid(int tenderId, int userId, int finalBid);
        Task<IEnumerable<Tender>> getuserprogresstender(int userId);
        Task<Tender> paytenderbid(int tenderId, int userId);
    }
}
