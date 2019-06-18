using A_Team.ATeam;
using A_Team.Data;
using A_Team.Interfaces;
using A_Team.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

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
            var jiraItemsToSend = _jiraInteractor.GetItems().Where(i => i.status == JiraStatusEnum.To_do);
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
            var rm = new ResourceManager(typeof(Templates));
            ResourceSet rs = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            DateTime currentdate = new DateTime();
            currentdate = DateTime.Now;
            DateTime deadline = new DateTime();
            deadline = currentdate.AddDays(7);
            foreach (var jiraItem in jiraItemsToSend)
            {
                var contact = contacts.FirstOrDefault(c => c.Country == jiraItem.Country);
                if (contact == null)
                    continue;
                var email = new EmailModel
                {
                    Country = jiraItem.Country,
                    EmailTo = contact.Email,
                    EmailSubject = subject,
                    EmailBody = string.Format(rs.GetString("EmailBody"), string.Format("{0}. of {1}, {2}.", currentdate.Day, currentdate.ToString("MMMM"), currentdate.Year)
                    , string.Format("{0}. of {1}, {2}.", deadline.Day, deadline.ToString("MMMM"), deadline.Year)),
                    EmailFrom = rs.GetString("EmailFrom"),
                //emailTemplate.CC = rs.GetString("CC"),
                    SMTPServer = rs.GetString("SMTPServer")
            };
                emails.Add(email);
            }


            _email.SendMails(emails);
            var updater = new JiraUpdater(jiraItemsToSend.ToList());
            updater.SendUpdatedItems();

        }
    }
}
