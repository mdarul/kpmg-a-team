using A_Team.Data;

namespace A_Team.Interfaces
{
    public class JiraItem
    {
        public JiraStatusEnum status;
        public string Country { get; set; }

        public JiraItem(){}

        public JiraItem(string country, JiraStatusEnum status)
        {
            this.status = status;
            this.Country = country;
        }
    }
}
