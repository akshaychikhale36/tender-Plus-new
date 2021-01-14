using System;
using System.Collections.Generic;
using System.Text;

namespace TenderPlus.Core.Models
{
    public class BiddingCore
    {
        public int TenderId { get; set; }
        public string InititalBid { get; set; }
        public string FinalBid { get; set; }
        public int AssigneeId { get; set; }
        public int ReporteeId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BiddingDate { get; set; }

        //public virtual UserCore Assignee { get; set; }
        //public virtual UserCore Reportee { get; set; }
        //public virtual TenderCore Tender { get; set; }
    }
}
