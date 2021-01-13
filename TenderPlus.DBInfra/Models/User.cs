using System;
using System.Collections.Generic;

namespace TenderPlus.DBInfra.Models
{
    public partial class User
    {
        public User()
        {
            BiddingAssignee = new HashSet<Bidding>();
            BiddingReportee = new HashSet<Bidding>();
            TenderUsers = new HashSet<TenderUsers>();
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

        public virtual Login IdNavigation { get; set; }
        public virtual ICollection<Bidding> BiddingAssignee { get; set; }
        public virtual ICollection<Bidding> BiddingReportee { get; set; }
        public virtual ICollection<TenderUsers> TenderUsers { get; set; }
    }
}
