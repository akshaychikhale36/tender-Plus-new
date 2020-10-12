using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class UserDBManager : IUserDBManager
    {
        private readonly TenderPlusDBContext _context;
        public UserDBManager()
        {

        }
    }
}
