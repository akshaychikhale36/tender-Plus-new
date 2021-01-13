using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual User User { get; set; }
    }
}
