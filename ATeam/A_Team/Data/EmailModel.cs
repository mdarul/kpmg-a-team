using A_Team.Interfaces;

namespace A_Team.Data
{
    public class EmailModel : IEmail
    {
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string Country { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string ReplyTo { get; set; }
        public string SMTPServer { get; set; }
    }
}
