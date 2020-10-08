using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class Login
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
