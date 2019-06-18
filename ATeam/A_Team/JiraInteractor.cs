using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using A_Team.Interfaces;

namespace A_Team
{
    public class JiraInteractor : IJiraInteractor
    {

        public List<JiraItem> GetItems()
        {
            var result = new HttpClient().GetStringAsync(
                $"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-1?filter=allopenissues").Result;

            return new List<JiraItem>();
        }

        public bool UpdateItems(List<JiraItem> items)
        {
            return true;
        }
    }
}
