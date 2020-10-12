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
    }
}
