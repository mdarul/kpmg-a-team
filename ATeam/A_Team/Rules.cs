using A_Team.ATeam;
using A_Team.Data;
using A_Team.Interfaces;
using System;
using System.Linq;

namespace A_Team
{
    public class Rules
    {
        private static readonly ContactsReader _cr = new ContactsReader();
        private static readonly IJiraInteractor _jiraInteractor;

        public static void RunRules()
        {
            var contacts = _cr.ReadContacts("C:/Users/mkielczewski/Desktop/Copy of Gdansk Hackathon - Jira Country contacts.csv ");
            var jiraItemsToSend = _jiraInteractor.GetItems().Where(i => i.status == JiraStatusEnum.ToDo);
            var date = DateTime.Now;
            string quarter;
            if (date.Month <= 3)
                quarter = $"First Quarter {date.Year}";
            else if (date.Month <= 6)
                quarter = $"Second Quarter {date.Year}";
            else if (date.Month <= 9)
                quarter = $"Third Quarter {date.Year}";
            else
                quarter = $"Fourth Quarter {date.Year}";

            foreach (var jiraItem in jiraItemsToSend)
            {
                var contact = contacts.FirstOrDefault(c => c.Country == jiraItem.Country);
            }

        }
    }
}
