using System.Collections.Generic;
using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public interface ILoginDBManager
    {
        Task<string> CreateDBLogin(Login login);
        Task<Login> GetDBLogin(string username, string password);
        Task<Login> GetDBLoginByUsername(string username);
    }
}
