using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class TenderDBManager : ITenderDBManager
    {
        private readonly TenderPlusDBContext _context;
        public TenderDBManager()
        {
                
        }
    }
}
