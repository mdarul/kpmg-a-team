using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_Team.Interfaces
{
    interface IJiraInteractor
    {
        List<JiraItem> GetItems();
        bool UpdateItems(List<JiraItem> items);
    }
}
