using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class TenderDBManager : ITenderDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public TenderDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }
    }
}
