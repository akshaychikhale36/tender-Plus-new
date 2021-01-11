using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class TenderDBManager : ITenderDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public TenderDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }

        public async Task<bool> CreateBidding(Bidding bidding)
        {
            var res = await _tenderPlusDBContext.Bidding.AddAsync(bidding);
            _tenderPlusDBContext.SaveChanges();
            return true;
        }

        public async Task<int> CreateTender(Tender tenderRequest)
        {
           var res=await  _tenderPlusDBContext.Tender.AddAsync(tenderRequest);
            _tenderPlusDBContext.SaveChanges();
            return  res.Entity.Id;
           //_tenderPlusDBContext.SaveChanges();
           //return true;
        }

        public async Task<bool> DeleteTender(int id)
        {
            var tender = await _tenderPlusDBContext.Tender.FindAsync(id);
            if (tender == null)
            {
                return true;
            }
            var bidding =await _tenderPlusDBContext.Bidding.FindAsync(tender.Id);
            _tenderPlusDBContext.Bidding.Remove(bidding);
            _tenderPlusDBContext.Tender.Remove(tender);
            await _tenderPlusDBContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Tender>> GetTenders()
        {
            return await _tenderPlusDBContext.Tender
                .Include(x=>x.Bidding)
                .Where(x=>x.Assignee==null)
                .ToListAsync();
        }

        public async Task<bool> UpdateBidding(Bidding biddingRequest)
        {
            _tenderPlusDBContext.Bidding.Update(biddingRequest);
            _tenderPlusDBContext.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateTender(Tender tenderRequest)
        {
            _tenderPlusDBContext.Tender.Update(tenderRequest);
            _tenderPlusDBContext.SaveChanges();
            return true;
        }
    }
}
