﻿using System;
using System.Collections.Generic;
using System.Text;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class BiddingDBManager:IBiddingDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public BiddingDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }
    }
}
