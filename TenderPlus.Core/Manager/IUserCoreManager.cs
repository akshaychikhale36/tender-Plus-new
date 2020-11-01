using System.Threading.Tasks;
using TenderPlus.Core.Models;

namespace TenderPlus.Core.Manager
{
    public interface IUserCoreManager
    {
        Task<UserCore> GetUser();
        Task<UserCore> CreateUser();
        Task<UserCore> UpdateUser();

    }
}
