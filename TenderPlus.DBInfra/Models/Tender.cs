using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Tender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public byte[] DemoImg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public decimal Pin { get; set; }

        public virtual Bidding Bidding { get; set; }
    }
}
