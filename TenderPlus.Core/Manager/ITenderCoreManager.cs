using System.Collections.Generic;
using System.Threading.Tasks;
using TenderPlus.Core.Models;

namespace TenderPlus.Core.Manager
{
    public interface ITenderCoreManager
    {
        Task<bool> CreateTender(TenderCore tender);
        Task<bool> UpdateTender(TenderCore tender);
        Task<bool> DeleteTender(int id);
        Task<IEnumerable<TenderCore>> GetTenderList();
        Task<bool> RegisterTender(int tenderid, int userid);
        Task<TenderCore> GetRegisters(int tenderid);
        Task<IEnumerable<TenderCore>> getUserRegisters( int userId);
        Task<IEnumerable<TenderCore>> getUserAssign(int userId);
    }
}
