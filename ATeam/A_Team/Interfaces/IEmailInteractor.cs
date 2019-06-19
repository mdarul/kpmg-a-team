using A_Team.Pages;
using Microsoft.Office.Interop.Outlook;
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
            int countProc = 0;
            foreach (var emailTemplate in mails)
            {
                countProc = +1;
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

                    Microsoft.Office.Interop.Outlook.Application oApp1 = new Microsoft.Office.Interop.Outlook.Application();
                    Microsoft.Office.Interop.Outlook.MailItem oMsg1 = (Microsoft.Office.Interop.Outlook.MailItem)oApp1.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    oMsg1.Body = emailTemplate.EmailBody;
                    int iPosition = (int)oMsg1.Body.Length + 1;
                    oMsg1.Subject = emailTemplate.EmailSubject;

                    // Add a recipient.
                    Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg1.Recipients;
                    Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(emailTemplate.EmailTo);
                    oRecip.Type = (int)OlMailRecipientType.olTo;
                    if (string.IsNullOrEmpty(emailTemplate.CC) == false)
                    {
                        Microsoft.Office.Interop.Outlook.Recipient oRecipcc = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(emailTemplate.CC);
                        oRecipcc.Type = (int)OlMailRecipientType.olCC;
                    }
                    oRecip.Resolve();

                    oMsg1.Send();


                    //oClient.Port = 25;
                    //oClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //oClient.UseDefaultCredentials = false;
           
                    //oClient.Host = emailTemplate.SMTPServer;
                    //oMail.IsBodyHtml = true;
                    //oMail.Subject = emailTemplate.EmailSubject;
                    //oMail.Body = EmailBody;
                    //oClient.Send(oMail);
                    //oMail.Dispose();
                }
            }
            if (countProc== mails.Count)
            {
                return true;
            }else
            return false;
        }
    }

   
}
