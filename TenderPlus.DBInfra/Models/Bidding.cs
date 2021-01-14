using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Bidding
    {
        public int TenderId { get; set; }
        public string InititalBid { get; set; }
        public string FinalBid { get; set; }
        public int? AssigneeId { get; set; }
        public int? ReporteeId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BiddingDate { get; set; }

        public virtual User Assignee { get; set; }
        public virtual User Reportee { get; set; }
        public virtual Tender Tender { get; set; }
    }
}
