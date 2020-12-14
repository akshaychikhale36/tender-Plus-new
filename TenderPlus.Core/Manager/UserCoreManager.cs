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
        private readonly ILoginDBManager _loginDBManager;
        public IMapper _mapper;
        public UserCoreManager(IUserDBManager userDBManager,IMapper mapper,ILoginDBManager loginDBManager)
        {
            _userDBManager = userDBManager;
            _mapper = mapper;
            _loginDBManager = loginDBManager;
        }

        public async Task<bool> CreateUser(LoginCore userc)
        {
            try
            {
                Login login = new Login()
                {
                    UserName = userc.UserName,
                    Password = userc.Password
                };
                var res1 = await _loginDBManager.CreateDBLogin(login);

                var res = await _loginDBManager.GetDBLoginByUsername(userc.UserName);

                User user = new User()
                {
                    Id = res.Id,
                    Aadhar = userc.user.Aadhar,
                    Email = userc.user.Email,
                    Telephone = userc.user.Telephone,
                    License = userc.user.License,
                    CompanyName = userc.user.CompanyName,
                    Name = userc.user.Email,
                    PanId = userc.user.PanId
                };
                var response = await _userDBManager.CreateDBUser(user);

                return response;
            }
            catch (System.Exception e)
            {

                throw;
            }
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
