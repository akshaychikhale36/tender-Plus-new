using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class TenderUsers
    {
        public int Id { get; set; }
        public int? TenderId { get; set; }
        public int? UserId { get; set; }

        public virtual Tender Tender { get; set; }
        public virtual User User { get; set; }
    }
}
