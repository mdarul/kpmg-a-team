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
            List<JiraItem> output = new List<JiraItem>();
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
                Regex regex = new Regex(@"\d\\"",\\""status\\"":\\""(?<status>[^\\]+)\\"",\\""summary\\"":\\""(?<summary>[^\\]+)", RegexOptions.Compiled); //SIM\-\\""\,\\""
                var resoult = new HttpClient().GetStringAsync(url).Result;
                MatchCollection matches = regex.Matches(resoult);
                foreach (Match match in matches)
                {
                    JiraItem item = new JiraItem();
                    item.Country = match.Groups["summary"].Value;
                    switch (match.Groups["status"].Value.Trim())
                    {
                        case "To Do":
                            item.status = Data.JiraStatusEnum.ToDo;
                            break;
                        case "Sign-off":
                            item.status = Data.JiraStatusEnum.SignOff;
                            break;
                    }

                    output.Add(item);
                }

                List<string> countrysTmp = new List<string>();
                List<JiraItem> tmpOutput = new List<JiraItem>();
                foreach (var item in output)
                {
                    if(!countrysTmp.Any(i => i == item.Country))
                    {
                        countrysTmp.Add(item.Country);
                        tmpOutput.Add(item);
                    }
                }

                output = tmpOutput;
            }
            return output;
        }
    }
}
