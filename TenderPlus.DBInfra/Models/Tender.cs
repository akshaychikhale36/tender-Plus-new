﻿using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Tender
    {
        public Tender()
        {
            TenderUsers = new HashSet<TenderUsers>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public byte[] DemoImg { get; set; }
        public string StartDate { get; set; }
        public string CloseDate { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Pin { get; set; }

        public virtual Bidding Bidding { get; set; }
        public virtual ICollection<TenderUsers> TenderUsers { get; set; }
    }
}
