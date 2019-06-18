using A_Team.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A_Team
{
    public class JiraInteractor : IJiraInteractor
    {
        public List<JiraItem> GetItems()
        {
            List<string> urls = new List<string>()
            {
                "http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-1?filter=allopenissues"
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-2?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-3?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-4?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-5?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-6?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-7?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-8?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-9?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-10?filter=allopenissues",
                //"http://chzhbapp521.ch.kworld.kpmg.com:8080/projects/SIM/issues/SIM-11?filter=allopenissues"

            };

            foreach (string url in urls)
            {
                Regex regex = new Regex(@"SIM\-\\""\,\\""status\\""\:\\""(?<status>[^\\])\\", RegexOptions.Compiled);
                var resoult = new HttpClient().GetAsync(url).Result;
                MatchCollection matches = regex.Matches(url);
            }
            return null;
        }
    }
}
