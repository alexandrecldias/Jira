using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.GetLinkCustomerSatisfaction.PayLoads
{

    public class ReturnFeedbackTokenKey
    {
        public string key { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public string token { get; set; }
        public int issueID { get; set; }
        public string userKey { get; set; }
    }

}
