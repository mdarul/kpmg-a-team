using A_Team.ATeam;
using A_Team.Data;
using A_Team.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Team
{
    public class Rules
    {
        private static readonly ContactsReader _cr = new ContactsReader();
        private static readonly IJiraInteractor _jiraInteractor = new JiraInteractor();
        private static readonly IEmailInteractor _email = new Email();

        public static void RunRules()
        {
            var contacts = _cr.ReadContacts("../Gdansk Hackathon - Jira Country contacts.csv");
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
            var subject = $"KPMG LINK Business Traveler - {quarter}";
            List<IEmail> emails = new List<IEmail>();
            foreach (var jiraItem in jiraItemsToSend)
            {
                var contact = contacts.FirstOrDefault(c => c.Country == jiraItem.Country);
                if (contact == null)
                    continue;
                var email = new EmailModel
                {
                    Country = jiraItem.Country,
                    EmailTo = contact.Email,
                    EmailSubject = subject
                };
                emails.Add(email);
            }


            _email.SendMails(emails);
            var updater = new JiraUpdater(jiraItemsToSend.ToList());
            updater.SendUpdatedItems();

        }
    }
}
