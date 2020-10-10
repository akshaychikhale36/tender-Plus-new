using System;
using System.Collections.Generic;
using System.Text;

namespace TenderPlus.Core.Models
{
    public class BiddingCore
    {
        public int TenderId { get; set; }
        public decimal InititalBid { get; set; }
        public decimal FinalBid { get; set; }
        public int AssigneeId { get; set; }
        public int ReporteeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual UserCore Assignee { get; set; }
        public virtual UserCore Reportee { get; set; }
        public virtual TenderCore Tender { get; set; }
    }
}
