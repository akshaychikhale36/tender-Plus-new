using System;
using System.Collections.Generic;
using System.Text;

namespace TenderPlus.Core.Models
{
    public class payment
    {
        public int amout { get; set; }
        public string currency { get; set; }
        public string receipt { get; set; }
        public string payment_capture { get; set; }
    }
}
