using System.Collections.Generic;

namespace lab6_EqualityAndComparison {
    public class ExampleContacts {
        public List<Contact> ExampleContactList=new List<Contact>();

        public ExampleContacts() {
            Contact Ivanov = new Contact();
            Ivanov.name = "Ivan Ivanov";
            Ivanov.phoneNumbers.Add("+380671234567");
            Ivanov.phoneNumbers.Add("+380939873546");
            Ivanov.phoneNumbers.Add("+380997364527");

            ExampleContactList.Add(Ivanov);

            Contact Petrov = new Contact();
            Petrov.name = "Petro Petrov";
            Petrov.phoneNumbers.Add("+380731786546");
            Petrov.phoneNumbers.Add("+380441726546");

            ExampleContactList.Add(Petrov);

            Contact Sidorov = new Contact();
            Sidorov.name = "Vasilij Sidorov";
            Sidorov.phoneNumbers.Add("+380445671423");
            Sidorov.phoneNumbers.Add("+380998762435");

            ExampleContactList.Add(Sidorov);
        }
    }
}
