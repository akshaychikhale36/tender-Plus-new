using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class TenderUsers
    {
        public int Id { get; set; }
        public int? TenderId { get; set; }
        public int? RegisteredUsers { get; set; }

        public virtual User RegisteredUsersNavigation { get; set; }
        public virtual Tender Tender { get; set; }
    }
}
