using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<bool> CreateDBUser(User user)
        {
            _tenderPlusDBContext.User.Add(user);
            try
            {
                await _tenderPlusDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public Task<User> GetDBUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateDBUser()
        {
            throw new System.NotImplementedException();
        }
        private bool UserExists(int id)
        {
            return _tenderPlusDBContext.User.Any(e => e.Id == id);
        }
    }
}
