using System;
using System.Collections.Generic;
using System.Text;

namespace TenderPlus.Core.Models
{
    public class LoginCore
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual UserCore User { get; set; }
    }
}
