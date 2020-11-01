using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class UserDBManager : IUserDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public UserDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }

        public Task<User> CreateDBUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetDBUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateDBUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
