using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC2018.Models
{
    public class Donate
    {
        public int PersonKey { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Guid ConfirmationCode { get; set; }
    }
}