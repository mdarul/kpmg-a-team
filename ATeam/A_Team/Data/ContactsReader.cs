using System.Collections.Generic;
using System.IO;

namespace A_Team
{
    namespace ATeam
    {
        public class Contact
        {
            public string Country { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
        public class ContactsReader
        {
            public List<Contact> ReadContacts(string path)
            {
                List<Contact> contacts = new List<Contact>();
                var lines = File.ReadLines(path);
                var counter = 0;
                foreach (var line in lines)
                {
                    counter++;
                    if (counter < 2)
                        continue;
                    var lineData = line.Split(';');
                    var contact = new Contact
                    {
                        Country = lineData[0],
                        FirstName = lineData[1],
                        LastName = lineData[2],
                        Email = lineData[3]
                    };
                    contacts.Add(contact);
                }

                return contacts;
            }
        }
    }

}
