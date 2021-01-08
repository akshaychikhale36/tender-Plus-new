using AutoMapper;
using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.Core.Provider;
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
                    Password = userc.Password,
                    Role=userc.Role

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
                    Name = userc.UserName,
                    PanId = userc.user.PanId
                };
                bool res2;
                var response = await _userDBManager.CreateDBUser(user);
                if (response)
                {
                     res2 =SmsProvider.SendSms(string.Concat("+91", userc.user.Telephone), "Welcome to Tender + Thanks for joining our services");
                }
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

        public async Task<LoginCore> getUserByID(string user)
        {
            try
            {
               
           

                var res = await _loginDBManager.GetDBLoginByUsername(user);
                LoginCore reslog = new LoginCore()
                {
                    UserName = res.UserName,
                    Role = res.Role,
                    Id = res.Id


                };

                return reslog;
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public Task<UserCore> UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
