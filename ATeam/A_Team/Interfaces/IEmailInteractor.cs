using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_Team.Interfaces
{
    interface IEmailInteractor
    {
        bool SendMails(List<IEmail> mails);
    }
}
