using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core.Manager
{
    public interface ILoginCoreManager
    {
        Task<LoginCore> GetLogin(string username, string password);
        Task<string> CreateLogin(LoginCore login);
    }
}
