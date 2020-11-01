using System;
using System.Collections.Generic;
using System.Text;
using TenderPlus.DBInfra.Manager;

namespace TenderPlus.Core.Manager
{
    public class TenderCoreManager:ITenderCoreManager
    {
        private readonly ITenderDBManager _tenderDBManager;
        public TenderCoreManager(ITenderDBManager tenderDBManager)
        {
            _tenderDBManager = tenderDBManager;
        }
    }
}
