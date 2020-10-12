using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
