using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC2018.Models
{
    public class GrantRequest
    {
        public int PersonKey { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int? GrantTypeKey { get; set; }
        public decimal? ApplicationRequestAmount { get; set; }
        public string ApplicationReason { get; set; }
        public int? GrantApplicationStatusKey { get; set; }
    }
}