using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A_Team.Data;
using A_Team.Interfaces;

namespace A_Team
{
    public class JiraUpdater: IJiraUpdater
    {
        public List<JiraItem> items { get; set; }

        public JiraUpdater(List<JiraItem> items)
        {
            this.items = items;
        }

        public bool SendUpdatedItems()
        {
            var updatedJiraItems = GetUpdatedJiraItems();
            UpdatedItemsExcelExporter.Export(updatedJiraItems);
            return true;
        }

        private List<JiraItem> GetUpdatedJiraItems()
        {
            var newList = new List<JiraItem>();
            foreach (var jiraItem in items.ToList())
            {
                switch (jiraItem.status)
                {
                    case JiraStatusEnum.To_do:
                        newList.Add(new JiraItem(jiraItem.Country, JiraStatusEnum.First_reminder_sent));
                        break;
                    case JiraStatusEnum.First_reminder_sent:
                        newList.Add(new JiraItem(jiraItem.Country, JiraStatusEnum.Second_reminder_sent));
                        break;
                    case JiraStatusEnum.Second_reminder_sent:
                        newList.Add(new JiraItem(jiraItem.Country, JiraStatusEnum.Sign_off));
                        break;
                }
            }

            return newList;
        }
    }
}
