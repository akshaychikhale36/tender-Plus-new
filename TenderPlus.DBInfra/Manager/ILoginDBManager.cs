using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public interface ILoginDBManager
    {
     
        Task<Login> GetDBLogin(string username);
        Task<string> CreateDBLogin(Login login);
    }
}
