using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Manager;

namespace TenderPlus.Core.Manager
{
    public class LoginCoreManager:ILoginCoreManager
    {
        private readonly ILoginDBManager _loginDBManager;
        public LoginCoreManager(ILoginDBManager loginDBManager)
        {
            _loginDBManager = loginDBManager;
        }

        public Task<LoginCore> CreateLogin()
        {
            throw new NotImplementedException();
        }

        public Task<LoginCore> GetLogin()
        {
            throw new NotImplementedException();
        }
    }
}
