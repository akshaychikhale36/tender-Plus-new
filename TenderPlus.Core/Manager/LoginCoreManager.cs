using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.Core.Provider;
using TenderPlus.DBInfra.Manager;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Core.Manager
{
    public class LoginCoreManager:ILoginCoreManager
    {
        private readonly ILoginDBManager _loginDBManager;
        public IMapper _mapper;
        public LoginCoreManager(ILoginDBManager loginDBManager, IMapper mapper)
        {
            _loginDBManager = loginDBManager;
            _mapper = mapper;
        }

        public async Task<string> CreateLogin(LoginCore login)
        {

            var loginDB = _mapper.Map<Login>(login);
            var res = await _loginDBManager.CreateDBLogin(loginDB);
            if (res== "Success")
            {
                SmsProvider.SendSms(login.user.Telephone,"Welcome to Tender + Thanks for joining our services");
            }
            return res;
        }

        public async Task<LoginCore> GetLogin(string username, string password)
        {
            var res = await _loginDBManager.GetDBLogin(username,password);
            var result = _mapper.Map<LoginCore>(res);
            return result;
        }

        public async Task<LoginCore> GetLoginByusername(string username)
        {
            var res = await _loginDBManager.GetDBLoginByUsername(username);
            var result = _mapper.Map<LoginCore>(res);
            return result;
        }
    }
}
