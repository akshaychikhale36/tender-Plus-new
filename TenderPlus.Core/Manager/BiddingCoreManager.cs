using System;
using System.Collections.Generic;
using System.Text;
using TenderPlus.DBInfra.Manager;

namespace TenderPlus.Core.Manager
{
    public class BiddingCoreManager:IBiddingCoreManager
    {
        private readonly IBiddingDBManager _biddingDBManager;
        public BiddingCoreManager(IBiddingDBManager biddingDBManager)
        {
            _biddingDBManager = biddingDBManager;
        }
    }
}
