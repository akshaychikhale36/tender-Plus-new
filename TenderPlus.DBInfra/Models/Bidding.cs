using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Bidding
    {
        public string TenderId { get; set; }
        public decimal InititalBid { get; set; }
        public decimal FinalBid { get; set; }
        public string AssigneeId { get; set; }
        public string ReporteeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual User Assignee { get; set; }
        public virtual User Reportee { get; set; }
        public virtual Tender Tender { get; set; }
    }
}
