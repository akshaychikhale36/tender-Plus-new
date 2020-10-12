using System.Threading.Tasks;
using TenderPlus.Core.Models;

namespace TenderPlus.Core.Manager
{
    public interface ILoginCoreManager
    {
        Task<LoginCore> GetLogin();
        Task<LoginCore> CreateLogin();
    }
}
