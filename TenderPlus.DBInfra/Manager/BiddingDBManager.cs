using System;
using System.Collections.Generic;
using System.Text;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class BiddingDBManager:IBiddingDBManager
    {
        private readonly TenderPlusDBContext _context;
        public BiddingDBManager()
        {

        }
    }
}
