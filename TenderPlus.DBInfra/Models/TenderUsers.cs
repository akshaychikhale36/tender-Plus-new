using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class TenderUsers
    {
        public int TenderId { get; set; }
        public int? RegisteredUsers { get; set; }

        public virtual User RegisteredUsersNavigation { get; set; }
    }
}
