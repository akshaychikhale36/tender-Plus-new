using AutoMapper;
using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Manager;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core.Manager
{
    public class UserCoreManager : IUserCoreManager
    {
        private readonly IUserDBManager _userDBManager;
        public IMapper _mapper;
        public UserCoreManager(IUserDBManager userDBManager)
        {
            _userDBManager = userDBManager;
        }

        public async Task<UserCore> CreateUser(UserCore user)
        {
            var request = _mapper.Map<User>(user);
            var response = await _userDBManager.CreateDBUser(request);
            var result = _mapper.Map<UserCore>(response);
            return result;
        }

        public Task<UserCore> GetUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserCore> UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
