using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_Team.Interfaces
{
    interface IEmail
    {
        string EmailSubject { get; set; }
        string EmailBody { get; set; }
        string EmailTo { get; set; }
        string EmailFrom { get; set; }
        string Country { get; set; }

        string CC { get; set; }
        string BCC { get; set; }
        string ReplyTo { get; set; }

        string SMTPServer { get; set; }
    }
}
