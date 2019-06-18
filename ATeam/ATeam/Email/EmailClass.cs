using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ATeam.Email
{
    class EmailClass
    {
        public static void SendPortalEmail(EmailTemplate emailTemplate)
        {
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

        public class EmailTemplate
        {
            public string EmailSubject { get; set; }
            public string EmailBody { get; set; }
            public string EmailTo { get; set; }
            public string EmailFrom { get; set; }

            public string CC { get; set; }
            public string BCC { get; set; }
            public string ReplyTo { get; set; }

            public string SMTPServer { get; set; }
        }
    }
}
