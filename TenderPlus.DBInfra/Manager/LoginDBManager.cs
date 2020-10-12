using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class LoginDBManager : ILoginDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public LoginDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }
        
        private bool LoginExists(string username)
        {
            return _tenderPlusDBContext.Login.Any(e => e.UserName == username);
        }

        public async Task<string> CreateDBLogin(Login login)
        {
            _tenderPlusDBContext.Login.Add(login);
            try
            {
                await _tenderPlusDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.UserName))
                {
                    return "Already Present";
                }
                else
                {
                    throw;
                }
            }

            return "Success";
        }

        public async Task<Login> GetDBLogin(string username)
        {
            var login = await _tenderPlusDBContext.Login.FindAsync(username);
            return login;
        }
    }
}
