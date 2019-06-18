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

        public bool SendUpdatedItems()
        {
            UpdateJiraItems();

            return true;
        }

        private void UpdateJiraItems()
        {
            foreach (var jiraItem in items.ToList())
            {
                switch (jiraItem.status)
                {
                    case JiraStatusEnum.ToDo:
                        jiraItem.status = JiraStatusEnum.FirstReminderSent;
                        break;
                    case JiraStatusEnum.FirstReminderSent:
                        jiraItem.status = JiraStatusEnum.SecondReminderSent;
                        break;
                    case JiraStatusEnum.SecondReminderSent:
                        jiraItem.status = JiraStatusEnum.SignOff;
                        break;
                }
            }
        }
    }
}
