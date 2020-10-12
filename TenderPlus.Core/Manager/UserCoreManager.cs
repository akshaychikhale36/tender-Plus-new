using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Manager;

namespace TenderPlus.Core.Manager
{
    public class UserCoreManager : IUserCoreManager
    {
        private readonly IUserDBManager _userDBManager;
        public UserCoreManager(IUserDBManager userDBManager)
        {
            _userDBManager = userDBManager;
        }

        public Task<UserCore> CreateUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserCore> GetUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserCore> UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
