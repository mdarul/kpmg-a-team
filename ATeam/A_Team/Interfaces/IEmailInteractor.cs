﻿using A_Team.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Resources;
using System.Threading.Tasks;

namespace A_Team.Interfaces
{
    interface IEmailInteractor
    {
        bool SendMails(List<IEmail> mails);
    }
    class Email : IEmailInteractor
    {
        public bool SendMails(List<IEmail> mails)
        {
            var rm = new ResourceManager(typeof(Templates));
            ResourceSet rs = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            DateTime currentdate = new DateTime();
            currentdate = DateTime.Now;
            foreach (var emailTemplate in mails)
            {
                emailTemplate.EmailBody = string.Format(rs.GetString("EmailBody"), string.Format("{0}. of {1}, {2}.", currentdate.Day, currentdate.ToString("MMMM"), currentdate.Year));
                emailTemplate.EmailFrom = rs.GetString("EmailFrom");
                emailTemplate.CC = rs.GetString("CC");
                emailTemplate.SMTPServer = rs.GetString("SMTPServer");
                
                var oMail = new MailMessage();
                string EmailBody = "";

                foreach (var address in emailTemplate.EmailTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(address)))
                    {
                        oMail.To.Add(address);
                    }
                }

                if (!string.IsNullOrEmpty(emailTemplate.ReplyTo))
                {
                    oMail.ReplyToList.Add(emailTemplate.ReplyTo.Replace(";", ","));
                }

                if (!string.IsNullOrEmpty(emailTemplate.EmailFrom))
                {
                    MailAddress fromAddress = new MailAddress(emailTemplate.EmailFrom);
                    oMail.From = fromAddress;
                }
                EmailBody += emailTemplate.EmailBody;

                using (var oClient = new SmtpClient())
                {
                    oClient.Port = 25;
                    oClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    oClient.UseDefaultCredentials = false;
                    oClient.Host = emailTemplate.SMTPServer;
                    oMail.IsBodyHtml = true;
                    oMail.Subject = emailTemplate.EmailSubject;
                    oMail.Body = EmailBody;
                    oClient.Send(oMail);
                    oMail.Dispose();
                }
            }
            return true;
        }
    }
   
}
