namespace TenderPlus.Core.Models
{

    public class TenderUsersCore
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int RegisteredUsers { get; set; }
        //public  TenderCore Tender { get; set; }
        public UserCore User { get; set; }
    }
}

