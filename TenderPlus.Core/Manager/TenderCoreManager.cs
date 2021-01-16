using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Manager;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core.Manager
{
    public class TenderCoreManager : ITenderCoreManager
    {
        private readonly ITenderDBManager _tenderDBManager;
        private readonly IMapper _mappper;
        public TenderCoreManager(ITenderDBManager tenderDBManager,IMapper mappper)
        {
            _tenderDBManager = tenderDBManager;
            _mappper = mappper;
        }

        public async Task<bool> CreateTender(TenderCore tender) => await PostDataToDB(tender);

        public async Task<bool> DeleteTender(int id)
        {
            bool res =await _tenderDBManager.DeleteTender(id);
            return res;
        }

        public async Task<TenderCore> GetRegisters(int tenderid)
        {
           Tender res = await _tenderDBManager.GetRegisters(tenderid);
            var result = _mappper.Map<Tender, TenderCore>(res);
            return result;
        }

        public async Task<int> getTenderBid(int tenderId)
        {
            Tender res = await _tenderDBManager.getTenderBid(tenderId);
            return Convert.ToInt32(res.Bidding.FinalBid);
        }

        public async Task<IEnumerable<TenderCore>> GetTenderList()
        {
            IEnumerable<Tender> res = await _tenderDBManager.GetTenders();
            var result = _mappper.Map<IEnumerable<Tender>, IEnumerable<TenderCore>>(res);
            return result;
        }

        public async Task<IEnumerable<TenderCore>> getUserAssign(int userId)
        {
            IEnumerable<Tender> res = await _tenderDBManager.getUserAssign(userId);
            var result = _mappper.Map<IEnumerable<Tender>, IEnumerable<TenderCore>>(res);
            return result;
        }

        public async Task<IEnumerable<TenderCore>> getuserprogresstender(int userId)
        {
            IEnumerable<Tender> res = await _tenderDBManager.getuserprogresstender(userId);
            var result = _mappper.Map<IEnumerable<Tender>, IEnumerable<TenderCore>>(res);
            return result;
        }

        public async Task<IEnumerable<TenderCore>> getUserRegisters( int userId)
        {
            IEnumerable<TenderUsers> res = await _tenderDBManager.GetUserTenders(userId);
            var result = _mappper.Map<IEnumerable<Tender>, IEnumerable<TenderCore>>(res.Select(x=>x.Tender));
            return result;
        }

        public async Task<bool> paytenderbid(int tenderId, int userId)
        {
            
            Tender res = await _tenderDBManager.paytenderbid(tenderId, userId);
            if (res == null)
            {
                return false;
            }
            return true;
        }

        public async Task<int> postTenderBid(int tenderId, int userId, int finalBid)
        {
           
            Tender res = await _tenderDBManager.postTenderBid( tenderId,  userId,  finalBid);
            if (res==null)
            {
                return 0;
            }
            return Convert.ToInt32(res.Bidding.FinalBid);
        }

        public async Task<bool> RegisterTender(int tenderid, int userid)
        {
            TenderUsers tenderUsers = new TenderUsers()
            {
                UserId=userid,
                TenderId=tenderid
            };
            bool res = await _tenderDBManager.RegisterTender(tenderUsers);
            return res;
        }

        public async Task<bool> UpdateTender(TenderCore tender) => await PostDataToDB(tender);

        private async Task<bool> PostDataToDB(TenderCore tender)
        {
          
            Tender tenderRequest = new Tender()
            {
                Location = tender.Location,
                Pin = tender.Pin,
                Reporter = tender.Reporter,
                StartDate = tender.StartDate,
                State = tender.State,
                Title = tender.Title,
                District = tender.District,
                Description = tender.Description,
                CloseDate = tender.CloseDate,
                Type = tender.Type,
                Assignee = tender.Assignee,
                //Bidding=bidding
            };
            if (string.IsNullOrEmpty( tender.Id.ToString())||tender.Id==0)
            {
                var res= await _tenderDBManager.CreateTender(tenderRequest);

                Bidding bidding = new Bidding()
                {
                    TenderId = res,
                    InititalBid = tender.Bidding.InititalBid,
                    EndTime = tender.Bidding.EndTime,
                    StartTime = tender.Bidding.StartTime,
                    ReporteeId = tender.Bidding.ReporteeId,
                    BiddingDate=tender.Bidding.BiddingDate
                };
                return await _tenderDBManager.CreateBidding(bidding);
            }
            else
            {
                Bidding biddingRequest = new Bidding()
                {
                    TenderId = tender.Bidding.TenderId,
                    InititalBid = tender.Bidding.InititalBid,
                    EndTime = tender.Bidding.EndTime,
                    StartTime = tender.Bidding.StartTime,
                    ReporteeId = tender.Bidding.ReporteeId,
                    BiddingDate = tender.Bidding.BiddingDate
                };
                tenderRequest.Id = tender.Id;
                 await _tenderDBManager.UpdateTender(tenderRequest);
                return await _tenderDBManager.UpdateBidding(biddingRequest);
            }
          
        }
    }
}
