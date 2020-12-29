using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class TenderUsers
    {
        public int TenderId { get; set; }
        public string RegisteredUsers { get; set; }

        public virtual Tender Tender { get; set; }
    }
}
