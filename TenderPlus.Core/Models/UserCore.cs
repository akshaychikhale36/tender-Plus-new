using System;
using System.Collections.Generic;
using System.Text;

namespace TenderPlus.Core.Models
{
    public class UserCore
    {
        public UserCore()
        {
            BiddingAssignee = new HashSet<BiddingCore>();
            BiddingReportee = new HashSet<BiddingCore>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Telephone { get; set; }
        public byte[] Avatar { get; set; }
        public string License { get; set; }
        public string Aadhar { get; set; }
        public string PanId { get; set; }
        public string CompanyName { get; set; }

        public virtual LoginCore IdNavigation { get; set; }
        public virtual ICollection<BiddingCore> BiddingAssignee { get; set; }
        public virtual ICollection<BiddingCore> BiddingReportee { get; set; }
    }
}
