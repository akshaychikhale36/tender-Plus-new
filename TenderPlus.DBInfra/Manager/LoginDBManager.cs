using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class LoginDBManager : ILoginDBManager
    {
        private readonly TenderPlusDBContext _context;
        public LoginDBManager()
        {

        }
    }
}
